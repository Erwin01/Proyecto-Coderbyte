using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SIGACUtilitarios.Models;

#nullable disable

namespace SIGACUtilitarios.Context
{
    public partial class SIGACDBContext : DbContext
    {
        public SIGACDBContext()
        {
        }

        public SIGACDBContext(DbContextOptions<SIGACDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SigacplusNotificacion> SigacplusNotificacions { get; set; }
        public virtual DbSet<SigacplusArchivoadjunto> SigacplusArchivoadjuntos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SIGACPLUS");

            modelBuilder.Entity<SigacplusNotificacion>(entity =>
            {
                entity.HasKey(e => e.NotifId)
                    .HasName("SYS_C0013659");

                entity.ToTable("SIGACPLUS_NOTIFICACION");

                entity.Property(e => e.NotifId)
                    .HasPrecision(10)
                    .HasColumnName("NOTIF_ID");

                entity.Property(e => e.NotifAsunto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_ASUNTO");

                entity.Property(e => e.NotifCierre)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_CIERRE");

                entity.Property(e => e.NotifCuerpo)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_CUERPO");

                entity.Property(e => e.NotifDisigac2IdEscuela)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_DISIGAC2_ID_ESCUELA");

                entity.Property(e => e.NotifEstado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_ESTADO")
                    .HasDefaultValueSql("'S' ");

                entity.Property(e => e.NotifFechacreacion)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_FECHACREACION");

                entity.Property(e => e.NotifFechamodificacion)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_FECHAMODIFICACION");

                entity.Property(e => e.NotifHost)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_HOST");

                entity.Property(e => e.NotifIpmaquina)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_IPMAQUINA");

                entity.Property(e => e.NotifPicbaIdNotif)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_PICBA_ID_NOTIF");

                entity.Property(e => e.NotifUsuariocreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_USUARIOCREACION");

                entity.Property(e => e.NotifUsuariomodificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_USUARIOMODIFICACION");

                entity.Property(e => e.NotifVariables)
                    .IsRequired()
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIF_VARIABLES");
            });

            modelBuilder.Entity<SigacplusArchivoadjunto>(entity =>
            {
                entity.HasKey(e => e.AradjId)
                    .HasName("SYS_C0012697");

                entity.ToTable("SIGACPLUS_ARCHIVOADJUNTO");

                entity.Property(e => e.AradjId)
                    .HasPrecision(10)
                    .HasColumnName("ARADJ_ID");

                entity.Property(e => e.AradjDescripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_DESCRIPCION");

                entity.Property(e => e.AradjEstado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_ESTADO")
                    .HasDefaultValueSql("'S' ");

                entity.Property(e => e.AradjFechacreacion)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_FECHACREACION");

                entity.Property(e => e.AradjFechamodificacion)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_FECHAMODIFICACION");

                entity.Property(e => e.AradjHost)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_HOST");

                entity.Property(e => e.AradjIdobjeto)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_IDOBJETO");

                entity.Property(e => e.AradjIpmaquina)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_IPMAQUINA");

                entity.Property(e => e.AradjNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_NOMBRE");

                entity.Property(e => e.AradjPicbaIdTabla)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_PICBA_ID_TABLA");

                entity.Property(e => e.AradjRuta)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_RUTA");

                entity.Property(e => e.AradjUsuariocreacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_USUARIOCREACION");

                entity.Property(e => e.AradjUsuariomodificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARADJ_USUARIOMODIFICACION");
            });

            modelBuilder.HasSequence("SIGACPLUS_ARCHIVOADJUNTO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ASIGESTRATEGIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ASIGNATURA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ASIGUNIDAD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ASIGUNIESTRATEGIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ARCHADJUNTO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ASIGESTRATE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ASIGNATURA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COHPERICOMP_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COHPROGESCU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COHPROGPERI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COHTEPROGRA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COMPGENERIC_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_COMPGENESTR_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_CONTENIPROG_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_DETALFAHIST_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_DETALLEFASE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_DISENOCURRI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ESTRATEGIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_FASES_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_FASESALERTA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_FASESREQUIS_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LISTACHEQUE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRACADE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRBASIC_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRBECA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRDISCU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRDOCEN_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRESTUD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_LOGERRTESOR_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_MENU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_NOTIFICACIO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_NOVEDAD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PARAMETRO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKACADEMI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKBASICA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKBECA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKDISCURR_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKDOCENTE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKESTUDIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKMASTER_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PICKTESORER_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PRERREQUISI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_PROGRAMA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_REFERENCIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_REQUISGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ROL_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_ROLMENU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_SOLICITUD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_TEMAS_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_USUARIO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_AUDIT_USUARIOROL_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COHORTEPERIODCOMP_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COHORTEPROGESCUE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COHORTEPROGPERIOD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COHORTEPROGRAMAC_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COMPETENCIAGEN_SQ");

            modelBuilder.HasSequence("SIGACPLUS_COMPGENESTRATEGIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_CONTENIDOPROG_SQ");

            modelBuilder.HasSequence("SIGACPLUS_DETALLEFASE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_DETALLEFASEHIST_SQ");

            modelBuilder.HasSequence("SIGACPLUS_DISENOCURRICULAR_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ESTRATEGIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_FASES_SQ");

            modelBuilder.HasSequence("SIGACPLUS_FASESALERTA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_FASESREQUISITOS_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LISTACHEQUEO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORACADEMICA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORBASICA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORBECA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORDISCURRI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORDOCENTE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORESTUDI_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_LOGERRORTESORERIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_MENU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_NOTIFICACION_SQ");

            modelBuilder.HasSequence("SIGACPLUS_NOVEDAD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PARAMETRO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKACADEMICA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKBASICA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKBECA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKDISCURRICULAR_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKDOCENTE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKESTUDIANTE_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKLISTMASTER_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PICKTESORERIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PLANESTUDIO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PLANESTUDIOASIG_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PRERREQUISITOS_SQ");

            modelBuilder.HasSequence("SIGACPLUS_PROGRAMA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_REFERENCIA_SQ");

            modelBuilder.HasSequence("SIGACPLUS_REQUISITOSGRADO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ROL_SQ");

            modelBuilder.HasSequence("SIGACPLUS_ROLMENU_SQ");

            modelBuilder.HasSequence("SIGACPLUS_SOLICITUD_SQ");

            modelBuilder.HasSequence("SIGACPLUS_TEMAS_SQ");

            modelBuilder.HasSequence("SIGACPLUS_USUARIO_SQ");

            modelBuilder.HasSequence("SIGACPLUS_USUARIOROL_SQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
