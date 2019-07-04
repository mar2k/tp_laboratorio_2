using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();

            Alumno a1 = new Alumno(1, "Mariano", "ovelar", "11", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            universidad += a1;
            try
            {
                Alumno a2 = new Alumno(2, "cintia", "ovelar", "11", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.Deudor);
                universidad += a2;
            }
            catch (AlumnoRepetidoException)
            {

                Assert.AreEqual(1, universidad.Alumnos.Count);
                return;
            }

            Assert.Fail("No se produjo la excepcion de alumno repetido");
        }

        [TestMethod]
        public void NacionalidadInvalidaException()
        {
            Universidad universidad = new Universidad();

            try
            {

                Alumno a1 = new Alumno(1, "Mariano", "ovelar", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                universidad += a1;
            }
            catch (NacionalidadInvalidaException)
            {
                Assert.AreEqual(0, universidad.Alumnos.Count);
            }

            try
            {

                Alumno a2 = new Alumno(1, "Mariano", "ovelar", "99999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                universidad += a2;
            }
            catch (NacionalidadInvalidaException)
            {
                Assert.Fail("El extranjero debería agregarse");
            }

            Assert.AreEqual(1, universidad.Alumnos.Count);
        }

        [TestMethod]
        public void ValidarNumero()
        {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(1, "cintia", "ovelar", "11111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            universidad += a1;
            Profesor i1 = new Profesor(1, "Mariano", "ovelar", "22222222", Persona.ENacionalidad.Argentino);
            universidad += i1;

            Assert.IsInstanceOfType(a1, typeof(Alumno));
            Assert.IsInstanceOfType(i1, typeof(Profesor));
            Assert.IsInstanceOfType(universidad, typeof(Universidad));

            Assert.IsInstanceOfType(a1.DNI, typeof(int));
            Assert.IsInstanceOfType(i1.DNI, typeof(int));

            Assert.IsInstanceOfType(universidad.Alumnos[0].DNI, typeof(int));
            Assert.IsInstanceOfType(universidad.Instructores[0].DNI, typeof(int));
        }

        [TestMethod]
        public void ValidarNulos()
        {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(1, "cintia", "ovelar", "11111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Profesor i1 = new Profesor(1, "Mariano", "ovelar", "99999999", Persona.ENacionalidad.Extranjero);
            Jornada jor = new Jornada(Universidad.EClases.SPD, i1);
            jor += a1;
            universidad += a1;
            universidad += i1;

            Assert.IsNotNull(universidad.Alumnos, "La lista de alumnos es nula");
            Assert.IsNotNull(universidad.Instructores, "La lista de profesores es nula");
            Assert.IsNotNull(universidad.Jornadas, "La lista de jornadas es nula");

            Assert.IsNotNull(a1.DNI, "Dni de alumno nulo");
            Assert.IsNotNull(a1.Apellido, "Apellido de alumno nulo");
            Assert.IsNotNull(a1.Nombre, "Nombre de alumno nulo");
            Assert.IsNotNull(a1.Nacionalidad, "Nacionalidad de alumno nulo");


            Assert.IsNotNull(i1.DNI, "Dni de profesor nulo");
            Assert.IsNotNull(i1.Apellido, "Apellido de profesor nulo");
            Assert.IsNotNull(i1.Nombre, "Nombre de profesor nulo");
            Assert.IsNotNull(i1.Nacionalidad, "Nacionalidad de profesor nulo");
            Assert.IsNotNull(i1.Nacionalidad, "Nacionalidad de profesor nulo");

        }

    }
}
