﻿// <auto-generated />
using System;
using BackEnd_DisciPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd_DisciPlanner.Migrations
{
    [DbContext(typeof(DisciPlannerDbContext))]
    [Migration("20240719182955_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.32");

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Creditos")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FaculdadeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FaculdadeId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Faculdade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Nome")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Faculdades");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemestreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("SemestreId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomizedLabel")
                        .HasColumnType("TEXT");

                    b.Property<int>("HorarioFim")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HorarioInicio")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Semestre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SemestreLabel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semestres");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumeroDaTurma")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemestreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("SemestreId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FaculdadeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HorarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FaculdadeId");

                    b.HasIndex("HorarioId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Periodos");
                });

            modelBuilder.Entity("GradeTurma", b =>
                {
                    b.Property<int>("GradesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurmasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GradesId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("GradeTurma");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Disciplina", b =>
                {
                    b.HasOne("BackEnd_DisciPlanner.Entities.Faculdade", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("FaculdadeId");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Grade", b =>
                {
                    b.HasOne("BackEnd_DisciPlanner.Entities.Aluno", "Aluno")
                        .WithMany("Grades")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DisciPlanner.Entities.Semestre", "Semestre")
                        .WithMany("Grades")
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Semestre");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Turma", b =>
                {
                    b.HasOne("BackEnd_DisciPlanner.Entities.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DisciPlanner.Entities.Semestre", "Semestre")
                        .WithMany("Turmas")
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Semestre");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Periodo", b =>
                {
                    b.HasOne("BackEnd_DisciPlanner.Entities.Faculdade", null)
                        .WithMany("Periodos")
                        .HasForeignKey("FaculdadeId");

                    b.HasOne("BackEnd_DisciPlanner.Entities.Horario", "Horario")
                        .WithMany("Periodos")
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DisciPlanner.Entities.Turma", null)
                        .WithMany("Periodos")
                        .HasForeignKey("TurmaId");

                    b.Navigation("Horario");
                });

            modelBuilder.Entity("GradeTurma", b =>
                {
                    b.HasOne("BackEnd_DisciPlanner.Entities.Grade", null)
                        .WithMany()
                        .HasForeignKey("GradesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DisciPlanner.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Aluno", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Faculdade", b =>
                {
                    b.Navigation("Disciplinas");

                    b.Navigation("Periodos");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Horario", b =>
                {
                    b.Navigation("Periodos");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Semestre", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("BackEnd_DisciPlanner.Entities.Turma", b =>
                {
                    b.Navigation("Periodos");
                });
#pragma warning restore 612, 618
        }
    }
}
