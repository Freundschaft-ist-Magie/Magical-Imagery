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
        Name = "Persönliches Nutzungsrecht",
        Description = "Diese Lizenz erlaubt dem Käufer, das erworbene Bild zu besitzen und für persönliche Zwecke zu verwenden. Es ist jedoch nicht gestattet, das Bild in irgendeiner Form zu reproduzieren, weiterzuverbreiten oder kommerziell zu nutzen. Das bedeutet, dass das Bild nicht zur Erzielung von Einnahmen, sei es durch Verkauf, Vermietung oder als Teil von bezahlten Inhalten oder Werbung, verwendet werden darf. Diese Lizenz eignet sich ideal für Käufer, die einzigartige Kunstwerke für ihre private Sammlung suchen, ohne die Absicht, diese kommerziell zu nutzen.",
        ShortDescription = "Besitzt ein Bild zur privaten Nutzung ohne die Möglichkeit der Weiterverbreitung oder kommerziellen Verwendung.",
      },
      new() {
        Id = 2,
        Name = "Erweiterte Nutzungsrechte",
        Description = "Mit dieser Lizenz erwirbt der Käufer umfassende Nutzungsrechte an dem Bild, einschließlich der Möglichkeit zur Verbreitung und Nutzung in verschiedenen Medien und Formaten. Der Käufer darf das Bild jedoch nicht direkt weiterverkaufen. Einkünfte, die indirekt durch das Bild generiert werden, wie zum Beispiel durch Abonnements einer Galerie oder als Teil von bezahlten Inhalten, erfordern die Angabe der Quelle. Diese Lizenz eignet sich für Unternehmen und Privatpersonen, die Bilder in ihrer Werbung, auf ihrer Website oder in sozialen Medien verwenden möchten, ohne sie als separate Einheiten zu verkaufen.",
        ShortDescription = "Erweiterte Nutzung des Bildes erlaubt, inklusive Verbreitung und Einbindung in Medien, jedoch ohne direkten Weiterverkauf.",
      },
      new() {
        Id = 3,
        Name = "Vollurheberrecht (All Rights Reserved)",
        Description = "Diese Lizenz verleiht dem Käufer volle Urheberrechte, wodurch er umfangreiche Freiheiten in der Nutzung des Bildes erhält. Der Käufer kann das Bild in jeglicher Form nutzen, weiterverbreiten und kommerziell verwerten. Es bleibt jedoch intern vermerkt, dass der Käufer das Bild vom originalen Webshop und seinen Künstlern erworben hat. Der Käufer darf das Bild nicht in einer Weise verwenden, die nach Meinung des Lizenzgebers unethisch ist.",
        ShortDescription = "Volle Urheberrechte mit der Möglichkeit, das Bild umfassend zu nutzen und kommerziell zu verwerten, jedoch mit ethischen Einschränkungen des Lizenzgebers.",
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
