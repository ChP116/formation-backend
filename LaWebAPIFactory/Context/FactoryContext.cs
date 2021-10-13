using LaWebAPIFactory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LaWebAPIFactory.Context
{
    public class FactoryContext : DbContext
    {
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Cursus> Cursus { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Stagiaire> Stagiaires { get; set; }

        public DbSet<Competence> Competences { get; set; }

        public FactoryContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Salle>()
                .ToTable("Classroom");

            modelBuilder.Entity<Salle>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Salle>()
                .Property(s => s.Id);

            modelBuilder.Entity<Salle>()
                .Property(sa => sa.Nom)
                .HasColumnName("Name")
                .HasMaxLength(100);

            modelBuilder.Entity<Salle>()
                .Property(sa => sa.Capacite)
                .HasColumnName("Capacity");

            modelBuilder.Entity<Salle>()
                .Property(sa => sa.Virtuel)
                .HasColumnName("Virtual");

            modelBuilder.Entity<Salle>()
                .HasOne(s => s.Adresse)
                .WithMany()
                .HasForeignKey("AdressId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Evaluation>()
                .ToTable("Rating");

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.Note)
                .HasColumnName("Grade");

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.Commentaires)
                .HasColumnName("Comments")
                .HasMaxLength(4000);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.StagiaireId)
                .HasColumnName("TraineeId");

            modelBuilder.Entity<Evaluation>()
               .HasOne(e => e.Stagiaire)
               .WithMany(s => s.Evaluations)
               .HasForeignKey(e => e.StagiaireId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.ModuleId)
                .HasColumnName("ModuleId");

            modelBuilder.Entity<Evaluation>()
               .HasOne(e => e.Module)
               .WithMany(s => s.Evaluations)
               .HasForeignKey(e => e.ModuleId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Adresse>()
                .ToTable("Adress");

            modelBuilder.Entity<Adresse>()
                .Property(a => a.Rue)
                .HasColumnName("Street")
                .HasMaxLength(255);

            modelBuilder.Entity<Adresse>()
                .Property(a => a.CodePostal)
                .HasColumnName("Zipcode")
                .HasMaxLength(10);

            modelBuilder.Entity<Adresse>()
                .Property(a => a.Ville)
                .HasColumnName("City")
                .HasMaxLength(4000);

            modelBuilder.Entity<Cursus>()
                .ToTable("Course");

            modelBuilder.Entity<Cursus>()
                .Property(c => c.Intitule)
                .HasColumnName("Title")
                .HasMaxLength(100);

            modelBuilder.Entity<Cursus>()
                .Property(c => c.DateDebut)
                .HasColumnName("Start_Date");

            modelBuilder.Entity<Cursus>()
                .Property(c => c.DateFin)
                .HasColumnName("End_Date");

            modelBuilder.Entity<Cursus>()
              .Property(c => c.GestionnaireId)
              .HasColumnName("Manager_Id");

            modelBuilder.Entity<Cursus>()
              .HasOne(c => c.Gestionnaire)
              .WithMany()
              .HasForeignKey(c => c.GestionnaireId);

            modelBuilder.Entity<Formateur>()
              .ToTable("Trainer");

            modelBuilder.Entity<Formateur>()
                .Property(f => f.Externe)
                .HasColumnName("Extern");

            modelBuilder.Entity<Formateur>()
                .Property(f => f.UtilisateurId)
                .HasColumnName("UserId");

            modelBuilder.Entity<Formateur>()
                .HasOne(f => f.Utilisateur)
                .WithOne(u => u.Formateur)
                .HasForeignKey<Formateur>(f => f.UtilisateurId);

            modelBuilder.Entity<Matiere>()
              .ToTable("Subject");

            modelBuilder.Entity<Module>()
                .ToTable("Module");

            modelBuilder.Entity<Module>()
                .Property(m => m.Duree)
                .HasColumnName("Duration");

            modelBuilder.Entity<Module>()
                .Property(m => m.DateDebut)
                .HasColumnName("Start_Date");

            modelBuilder.Entity<Module>()
                .Property(m => m.DateFin)
                .HasColumnName("End_Date");

            modelBuilder.Entity<Module>()
                .Property(m => m.CursusId)
                .HasColumnName("CourseId");

            modelBuilder.Entity<Module>()
              .HasOne(m => m.Cursus)
              .WithMany(c => c.Modules)
              .HasForeignKey(m => m.CursusId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Module>()
                .Property(m => m.FormateurId)
                .HasColumnName("TrainerId");

            modelBuilder.Entity<Module>()
              .HasOne(m => m.Formateur)
              .WithMany(c => c.Modules)
              .HasForeignKey(m => m.FormateurId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Module>()
                .Property(m => m.MatiereId)
                .HasColumnName("SubjectId");

            modelBuilder.Entity<Module>()
              .HasOne(m => m.Matiere)
              .WithMany(c => c.Modules)
              .HasForeignKey(m => m.MatiereId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Module>()
                .Property(m => m.SalleId)
                .HasColumnName("ClassroomId");

            modelBuilder.Entity<Module>()
              .HasOne(m => m.Salle)
              .WithMany(c => c.Modules)
              .HasForeignKey(m => m.SalleId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Personne>()
                .ToTable("Person");

            modelBuilder.Entity<Personne>()
               .Property(p => p.PersonneType)
               .HasColumnName("PersonType");

            modelBuilder.Entity<Personne>()
               .HasDiscriminator(p => p.PersonneType)
               .HasValue<Stagiaire>("Trainee")
               .HasValue<Utilisateur>("User");

            modelBuilder.Entity<Personne>()
                .Property(p => p.Civilite)
                .HasColumnName("Civility")
                .HasConversion<string>();

            modelBuilder.Entity<Personne>()
                .Property(p => p.Nom)
                .HasColumnName("Lastname");

            modelBuilder.Entity<Personne>()
                .Property(p => p.Prenom)
                .HasColumnName("Firstname");

            modelBuilder.Entity<Personne>()
                .Property(p => p.Email)
                .HasColumnName("Email");

            modelBuilder.Entity<Personne>()
                .Property(p => p.Telephone)
                .HasColumnName("Phonenumber");

            modelBuilder.Entity<Personne>()
                .Property(p => p.AdresseId)
                .HasColumnName("AdressId");

            modelBuilder.Entity<Personne>()
               .HasOne(p => p.Adresse)
               .WithMany()
               .HasForeignKey(p => p.AdresseId);

            modelBuilder.Entity<Stagiaire>()
                .Property(s => s.CursusId)
                .HasColumnName("CourseId");

            modelBuilder.Entity<Stagiaire>()
                .HasOne(s => s.Cursus)
                .WithMany(c => c.Stagiaires)
                .HasForeignKey(s => s.CursusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Stagiaire>()
                .Property(s => s.DateNaissance)
                .HasColumnName("birthdate");

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Identifiant)
                .HasColumnName("Login");

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.MotDePasse)
                .HasColumnName("Password");

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Role)
                .HasColumnName("Role")
                .HasConversion<string>();

            modelBuilder.Entity<Competence>()
                .ToTable("Skills");

            modelBuilder.Entity<Competence>()
                .HasKey(c => new { c.FormateurId, c.MatiereId });

            modelBuilder.Entity<Competence>()
                .Property(c => c.FormateurId)
                .HasColumnName("TrainerId");

            modelBuilder.Entity<Competence>()
                .Property(c => c.MatiereId)
                .HasColumnName("SubjectId");

            modelBuilder.Entity<Competence>()
                .HasOne(c => c.Formateur)
                .WithMany(f => f.Competences)
                .HasForeignKey(c => c.FormateurId);

            modelBuilder.Entity<Competence>()
                .HasOne(c => c.Matiere)
                .WithMany(m => m.Competences)
                .HasForeignKey(c => c.MatiereId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LaWebAPIFactory.Models.Utilisateur> Utilisateur { get; set; }

        public DbSet<LaWebAPIFactory.Models.Evaluation> Evaluation { get; set; }

    }


}
