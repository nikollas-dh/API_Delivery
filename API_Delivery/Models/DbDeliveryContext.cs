using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Delivery.Models;

public partial class DbDeliveryContext : DbContext
{
    public DbDeliveryContext()
    {
    }

    public DbDeliveryContext(DbContextOptions<DbDeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Entregador> Entregadors { get; set; }

    public virtual DbSet<FraseSecretum> FraseSecreta { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<RecuperarSenha> RecuperarSenhas { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    public virtual DbSet<StatusPedido> StatusPedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=dbDelivery;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__EBE80EA1A71E6CC6");

            entity.ToTable("Administrador");

            entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK__Administr__idRes__5EBF139D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Administr__idUsu__5FB337D6");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE2CA5171D");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Cliente__idUsuar__60A75C0F");
        });

        modelBuilder.Entity<Entregador>(entity =>
        {
            entity.HasKey(e => e.IdEntregador).HasName("PK__Entregad__D7F5BF37E9B96B1D");

            entity.ToTable("Entregador");

            entity.Property(e => e.IdEntregador).HasColumnName("idEntregador");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Placa)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Entregadors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Entregado__idUsu__619B8048");
        });

        modelBuilder.Entity<FraseSecretum>(entity =>
        {
            entity.HasKey(e => e.IdFrase).HasName("PK__FraseSec__CA66FFBF041497EA");

            entity.Property(e => e.IdFrase).HasColumnName("idFrase");
            entity.Property(e => e.Frase)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("PK__ItemPedi__126CEFD7F730C98D");

            entity.ToTable("ItemPedido");

            entity.Property(e => e.IdItemPedido).HasColumnName("idItemPedido");
            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.IdProduto).HasColumnName("idProduto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__ItemPedid__idPed__628FA481");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__ItemPedid__idPro__6383C8BA");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__A9F619B7BBBA5847");

            entity.ToTable("Pedido");

            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoEntrega)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEntregador).HasColumnName("idEntregador");
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedido__idClient__6477ECF3");

            entity.HasOne(d => d.IdEntregadorNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEntregador)
                .HasConstraintName("FK__Pedido__idEntreg__656C112C");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK__Pedido__idRestau__66603565");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__Pedido__idStatus__6754599E");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__5EEDF7C3E22A6556");

            entity.ToTable("Produto");

            entity.Property(e => e.IdProduto).HasColumnName("idProduto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK__Produto__idResta__68487DD7");
        });

        modelBuilder.Entity<RecuperarSenha>(entity =>
        {
            entity.HasKey(e => e.IdRecuperacao).HasName("PK__Recupera__1C26205F4B5E43D9");

            entity.ToTable("RecuperarSenha");

            entity.Property(e => e.IdRecuperacao).HasColumnName("idRecuperacao");
            entity.Property(e => e.IdFrase).HasColumnName("idFrase");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.RespostaSecreta)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFraseNavigation).WithMany(p => p.RecuperarSenhas)
                .HasForeignKey(d => d.IdFrase)
                .HasConstraintName("FK__Recuperar__idFra__693CA210");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RecuperarSenhas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Recuperar__idUsu__6A30C649");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.IdRestaurante).HasName("PK__Restaura__5E9CB8F2353E9671");

            entity.ToTable("Restaurante");

            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusPedido>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__StatusPe__01936F74BB881B4E");

            entity.ToTable("StatusPedido");

            entity.Property(e => e.IdStatus)
                .ValueGeneratedNever()
                .HasColumnName("idStatus");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A66107BC38");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
