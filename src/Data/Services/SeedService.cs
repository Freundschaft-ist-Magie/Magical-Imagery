using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;
public static class SeedService {
  public static async Task SeedDb(this ApplicationDbContext context) {
    context.Database.Migrate();

    if (context.Products.Any())
      return;

    var licences = await SeedLicences(context);
    var comments = await SeedComments(context);
    await SeedProducts(context, licences, comments);
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

  private static async Task<List<Comment>> SeedComments(ApplicationDbContext context) {
    List<Comment> comments = [
      new() {
        Id = 1,
        Author = "Max Mustermann",
        Content = "Ein wirklich beeindruckendes Kunstwerk! Die Farben und die Details sind einfach atemberaubend.",
        ProfileImage = "https://loremflickr.com/40/40/dog"
      },
      new() {
        Id = 2,
        Author = "Erika Mustermann",
        Content = "Ich liebe dieses Bild! Es passt perfekt in mein Wohnzimmer und verleiht dem Raum eine ganz besondere Atmosphäre.",
        ProfileImage = "https://loremflickr.com/40/40/cat"
      },
      new() {
        Id = 3,
        Author = "John Doe",
        Content = "Fantastisches Kunstwerk! Ich bin begeistert von der Detailgenauigkeit und der Farbgebung.",
        ProfileImage = "https://loremflickr.com/40/40/paris"
      },
      new() {
        Id = 4,
        Author = "Jane Doe",
        Content = "Die Farben und Schattierungen sind einfach wunderschön! Ein echter Blickfang in jedem Raum.",
        ProfileImage = "https://loremflickr.com/40/40/berlin"
      },
      new() {
        Id = 5,
        Author = "Kevin Müller",
        Content = "Ein echtes Meisterstück der Kunst! Die Kombination aus Licht und Schatten ist einfach faszinierend.",
        ProfileImage = "https://loremflickr.com/40/40/london"
      },
      new() {
        Id = 6,
        Author = "Laura Schmidt",
        Content = "Ein wunderschönes Bild! Die Farben und die Stimmung sind einfach einzigartig.",
        ProfileImage = "https://loremflickr.com/40/40/girl"
      }
    ];

    await context.AddRangeAsync(comments);
    return comments;
  }

  private static async Task SeedProducts(ApplicationDbContext context, IEnumerable<Licence> licences, IEnumerable<Comment> comments) {
    List<Product> products = [
      new() {
        Id = 1,
        Name = "Flüsternde Schatten",
        Image = "./Images/finstere_schatten.webp",
        Description = "Tauchen Sie ein in die geheimnisvolle Welt der \"Flüsternden Schatten\". Dieses Kunstwerk entführt Sie in einen mystischen Wald, in dem das Licht zauberhafte Schatten wirft und eine atemberaubende Atmosphäre schafft. Ein Meisterwerk, das in jedem Raum eine besondere Stimmung verbreitet.",
        Tags = ["Wald", "Schatten", "Mystisch"],
        Price = 60,
        Likes = 5,
        Format = Enums.ImageFormat.Square,
        Width = 1024,
        Height = 1024,
        LicenceId = licences.First().Id,
        Comments = comments.Take(1).ToList()
      },
      new() {
        Id = 2,
        Name = "Evertale",
        Image = "./Images/evertale.webp",
        Description = "Das Kunstwerk \"Evertale\" entführt Sie in eine Welt voller Magie und Abenteuer. Lassen Sie sich von den leuchtenden Farben und den detailreichen Motiven verzaubern und tauchen Sie ein in eine Welt voller Geheimnisse und Wunder.",
        Tags = ["Fantasy", "Magie", "Abenteuer"],
        Price = 130,
        Likes = 45,
        Format = Enums.ImageFormat.Landscape,
        Width = 1792,
        Height = 1024,
        LicenceId = licences.Skip(1).First().Id,
        Comments = comments.Skip(1).Take(3).ToList()
      },
      new() {
        Id = 3,
        Name = "Wächter der Wüstenwelten",
        Image = "./Images/guardian.jpg",
        Description = "Ein mächtiger Echsenkrieger steht inmitten einer weiten Wüstenlandschaft, seine muskulöse Gestalt strahlt Stärke und Entschlossenheit aus. Mit prachtvollen Schmuckstücken und einem imposanten, königlichen Gewand ausgestattet, verkörpert er die majestätische Herrschaft über sein Reich. Sein Blick ist stolz und wachsam, bereit, sein Land gegen jegliche Bedrohung zu verteidigen.",
        Tags = ["Wüste", "Echse", "Krieger", "Fantasy"],
        Price = 25,
        Likes = 12,
        Format = Enums.ImageFormat.Portrait,
        Width = 512,
        Height = 768,
        LicenceId = licences.Last().Id,
        Comments = comments.Skip(4).Take(2).ToList()
      }
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
