using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
         
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Radnor Lake", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/thumbs/5b4b5be386b22dccb1e8c378650c57003256bc8ba086564db01bdd0b6b4cedea-375.jpg"},
        new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Big Guy", ImageUrl="https://d3qvqlc701gzhm.cloudfront.net/thumbs/f837ae841d368563c7abf762e6568cc1aa555bc4baa5b472f87a3ec27712babf-500.jpg"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Lunk Lounge Lake", ImageUrl="https://media.wgrz.com/assets/WGRZ/images/f8e66d89-e822-4dc5-89c3-670a511ec369/f8e66d89-e822-4dc5-89c3-670a511ec369_1140x641.jpg"},
        new Campsite {Id = 5, CampsiteTypeId = 2, Nickname = "Daru Hills", ImageUrl="https://static.wikia.nocookie.net/malazan/images/9/9f/City_of_azure_fire_by_artsed-d8wxrup.jpg/revision/latest/scale-to-width-down/400?cb=20150718150949"},
        new Campsite {Id = 6, CampsiteTypeId = 3, Nickname = "Malaz Island", ImageUrl="https://external-preview.redd.it/aFYOgpR9aQRHJ1nuP7JidCIFYvtSrXcRRPdsFpYeTFw.jpg?auto=webp&s=b0bfcb42089e360e5e560be504126e543b71f88c"}
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
        new UserProfile {Id = 1, FirstName = "Kalam", LastName = "Mekhar", Email = "burnsSleep23@gmail.com"}
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
        new Reservation {Id = 1, CampsiteId = 1, CheckinDate = new DateTime(2024,12,2), CheckoutDate = new DateTime(2024,12,5), UserProfileId = 1}
        });


    }
}