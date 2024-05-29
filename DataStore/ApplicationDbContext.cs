 using System;
using dontnetstarter.Models;
using Microsoft.EntityFrameworkCore;

namespace dontnetstarter.DataStore
{
	public class ApplicationDbContext : DbContext
  {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<VillaModel> villas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VillaModel>().HasData(
				new VillaModel()
					{
							id = 1,
							name = "Luxury Villa",
							details = "A luxurious villa with ocean views and a private pool.",
							rate = 500.00,
							sqft = 3000,
							occupancy = 8,
							imageurl = "https://example.com/images/luxury_villa.jpg",
							amenity = "Pool, Ocean View, Wi-Fi",
							created_at = DateTime.Now.AddMonths(-6),
							updated_at = DateTime.Now
					},
					new VillaModel()
					{
							id = 2,
							name = "Cozy Cottage",
							details = "A quaint cottage perfect for a romantic getaway.",
							rate = 150.00,
							sqft = 800,
							occupancy = 2,
							imageurl = "https://example.com/images/cozy_cottage.jpg",
							amenity = "Fireplace, Garden View, Wi-Fi",
							created_at = DateTime.Now.AddMonths(-8),
							updated_at = DateTime.Now
					},
					new VillaModel()
					{
							id = 3,
							name = "Modern Apartment",
							details = "A stylish apartment in the heart of the city.",
							rate = 200.00,
							sqft = 1200,
							occupancy = 4,
							imageurl = "https://example.com/images/modern_apartment.jpg",
							amenity = "Gym, City View, Wi-Fi",
							created_at = DateTime.Now.AddMonths(-3),
							updated_at = DateTime.Now
					},
					new VillaModel()
					{
							id = 4,
							name = "Rustic Cabin",
							details = "A secluded cabin in the woods for a nature retreat.",
							rate = 180.00,
							sqft = 1000,
							occupancy = 4,
							imageurl = "https://example.com/images/rustic_cabin.jpg",
							amenity = "Hiking Trails, Fireplace, Wi-Fi",
							created_at = DateTime.Now.AddMonths(-12),
							updated_at = DateTime.Now
					},
					new VillaModel()
					{
							id = 5,
							name = "Beachfront Bungalow",
							details = "A charming bungalow with direct beach access.",
							rate = 300.00,
							sqft = 1500,
							occupancy = 6,
							imageurl = "https://example.com/images/beachfront_bungalow.jpg",
							amenity = "Beach Access, Ocean View, Wi-Fi",
							created_at = DateTime.Now.AddMonths(-4),
							updated_at = DateTime.Now
					}
			);
		}
	}
}

