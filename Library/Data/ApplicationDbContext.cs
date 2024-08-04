using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Seed();
		}

		private void Seed()
		{
			if (!Libraries.Any())
			{
				LibraryModel newlibary = new()
				{
					Genre = "Fantasy",
					Shelfs =
					[
						new ()
						{
							Height = 50,
							Width = 100,
							Sets =
							[
								new ()
								{
									Name = "Harry Potter",
									Books =
									[
										new ()
										{
											Name = "Harry Potter and the Philosopher's Stone",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Chamber of Secrets",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Prisoner of Azkaban",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Goblet of Fire",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Order of the Phoenix",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Half-Blood Prince",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										},
										new ()
										{
											Name = "Harry Potter and the Deathly Hallows",
											Genre = "Fantasy",
											Height = 40,
											Width = 10
										}
									]
								}
							]
						}
					]
				};
				Libraries.Add(newlibary);
				SaveChangesAsync();
			}
		}

		public DbSet<LibraryModel> Libraries { get; set; }
		public DbSet<ShelfModel> Shelves { get; set; }
		public DbSet<SetModel> Sets { get; set; }
		public DbSet<BookModel> Books { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LibraryModel>()
				.HasMany(library => library.Shelfs)
				.WithOne(shelf => shelf.Library)
				.HasForeignKey(shelf => shelf.LibraryId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ShelfModel>()
				.HasMany(shelf => shelf.Sets)
				.WithOne(set => set.Shelf)
				.HasForeignKey(set => set.ShelfId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SetModel>()
				.HasMany(set => set.Books)
				.WithOne(book => book.Set)
				.HasForeignKey(book => book.SetId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
