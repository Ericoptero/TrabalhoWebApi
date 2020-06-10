namespace RestAPIProject.Models.ModelData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public partial class ModelProjectDB : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelProjectDB()
            : base("name=ModelProjectDB")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Contato> Contatos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Pais> Paises { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Produto> Produtos { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Fone)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .Property(e => e.Abreviacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Preco)
                .HasPrecision(9, 2);
        }
    }
}
