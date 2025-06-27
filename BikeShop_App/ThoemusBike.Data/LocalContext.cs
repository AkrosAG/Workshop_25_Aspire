using ThoemusBike.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ThoemusBike.Data;

public class LocalContext(DbContextOptions<LocalContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    [ExcludeFromCodeCoverage]
    public void MigrateAndCreateData()
    {
        Database.Migrate();

        if (Products.Any())
        {
            Products.RemoveRange(Products);
            SaveChanges();
        };

        Products.Add(new Product
        {
            Name = "Cube Kathmandu Hybrid one",
            Category = "eBike",
            Price = 3299.00,
            Description =
                "Simply unleash your inner adventurer: The Kathmandu Hybrid from CUBE is the perfect e-touring bike for the job! For this globetrotter, we've equipped it with a powerful Bosch drive system, installed a sturdy, elegantly integrated luggage rack, and given the frame a comfortable, safe geometry. In other words, everything you need for that grand journey to distant places. So where will your travels take you?",
            ImgUrl = "/images/Cube_Kathmandu_Hybrid_one.png"
        });
        Products.Add(new Product
        {
            Name = "Thömus SWISSRIDER ROAD",
            Category = "eBike",
            Price = 5250.00,
            Description =
                "The fully integrated electric road bike of the next generation. Light, quiet and dynamic. With maxon drive technology from the NASA program, you glide through space and time.",
            ImgUrl = "/images/SWISSRIDER_BLACK-XTR-formatted.png"
        });
        Products.Add(new Product
        {
            Name = "Stromer ST1- Suspension fork Sport",
            Category = "eBike",
            Price = 7340.00,
            Description =
           "The ST1 accelerates silently up to 45 km/h, while high-volume tires ensure a safe riding experience. This entry-level model is also connected via Bluetooth. With a range of up to 120 km, the ST1 is a versatile everyday companion.",
            ImgUrl = "/images/ST1_SPORT.png"
        });
        Products.Add(new Product
        {
            Name = "Cube Aim SLX Allroad",
            Category = "Road",
            Price = 639.00,
            Description =
                "The Aim Allroad frame sets new standards when it comes to versatility. It comes equipped with fenders, luggage rack and lighting system, making it ready to go straight out of the box for whatever is demanded of it. We've also given it a threaded bottom bracket and routed the cables internally so they'll do their job for a long time and can be easily serviced. The mount for a flat mount disc brake is seamlessly integrated into the kickstand mount. The special geometry features a lower top tube for super-reliable handling and provides plenty of clearance for wide, grippy, comfortable-rolling 2.25-inch tires. Plus, our Size Split System offers a broad range – so you're sure to find the Aim that fits you perfectly.",
            ImgUrl = "/images/synqup_841270_S_00.png"
        });
        Products.Add(new Product
        {
            Name = "Thömus SLIKER PRO ULTIMATE",
            Category = "Road",
            Price = 2990.00,
            Description =
                "With the Sliker Pro Ultimate, Thömus presents what may be the world's most advanced road bike. With optimized aerodynamics, total integration of cables and other components, minimal weight, maximum stiffness and riding comfort, Thömus sets new standards. With Shimano DURA-ACE Di2 or ULTEGRA Di2, we also rely on top technology for shifting and derailleurs. Thanks to the MyColor concept, you can make your Sliker Pro Ultimate even more individual! Combine your frame and secondary color, as well as the color of your handlebar tape from a wide selection exactly to your taste.",
            ImgUrl = "/images/Sliker-Pro-Ultimate-rot-Dura-Ace-Di2-2022.png"
        });

        SaveChanges();
    }
}
