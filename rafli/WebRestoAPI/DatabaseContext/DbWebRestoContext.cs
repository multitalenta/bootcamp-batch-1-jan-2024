using Microsoft.EntityFrameworkCore;
using WebRestoAPI.Models;

namespace WebRestoAPI.DatabaseContext;

    public partial class DbWebRestoContext : DbContext
    {
        public DbWebRestoContext()
        {
        }

        public DbWebRestoContext(DbContextOptions<DbWebRestoContext> options)
            : base(options)
        {
        }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RAFLI\\SQLEXPRESS;Database=db_resto3a;User Id=sa;Password=12345678;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
           }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}