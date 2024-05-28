using Data.Models;

namespace Data.Services;
public static class SeedService {
  public static async Task SeedDb(this ApplicationDbContext context) {
    if (context.Products.Any())
      return;

    var licences = await SeedLicences(context);
    await SeedProducts(context, licences);
    await SeedMaintances(context);
    await context.SaveChangesAsync();
  }

  private static async Task<List<Licence>> SeedLicences(ApplicationDbContext context) {
    List<Licence> licences = [
        new() {
          Id = 1,
          Name = "MIT",
        },
      new() {
        Id = 2,
        Name = "Non-Commercial",
      },
    ];

    await context.AddRangeAsync(licences);
    return licences;
  }

  private static async Task SeedProducts(ApplicationDbContext context, IEnumerable<Licence> licences) {
    List<Product> products = [
        new() {
          Id = 1,
          Name = "Flüsternde Schatten",
          Price = 130,
          Width = 1920,
          Height = 1080,
          LicenceId = licences.First().Id,
        },
      new() {
        Id = 2,
        Name = "Ewige Dämmerung",
        Price = 60,
        Width = 1920,
        Height = 1080,
        LicenceId = licences.Last().Id,
      },
    ];

    await context.AddRangeAsync(products);
  }

  private static async Task SeedMaintances(ApplicationDbContext context) {
    List<Maintenance> maintenances = [
      new() {
        Id = 1,
        Message = "Wir erweitern die Server Kapazitäten. Daher wird es zu einer kurzen Downtime kommen.",
        Reason = "Erweiterung der Server Kapazitäten",
        Schedules = [DateTime.Now.AddHours(216), DateTime.Now.AddHours(220)],
      },
      new() {
        Id = 2,
        Message = "4 Stunden Downtime in der Zukunft",
        Reason = "(╯°□°）╯︵ ┻━┻",
        Schedules = [DateTime.Now.AddHours(366), DateTime.Now.AddHours(340)],
      },
    ];

    await context.AddRangeAsync(maintenances);
  }
}
