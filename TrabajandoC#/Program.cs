// See https://aka.ms/new-console-template for more information

/*
 Crear una clase Curso con las siguientes propiedades:

Nombre (string)
Codigo (string)
Creditos (int)
Y el siguiente método:

MostrarDetalles(): Método que imprime los detalles del curso.
Crear una clase Estudiante con las siguientes propiedades:

Nombre (string)
Apellido (string)
Matricula (string)
Lista de cursos (List<Curso>) que representa los cursos en los que está inscrito el estudiante.
Y los siguientes métodos:

AgregarCurso(Curso curso): Para agregar un curso a la lista de cursos.
MostrarCursos(): Para mostrar todos los cursos en los que está inscrito el estudiante.
Crear una clase GestorEstudiantes que contenga:

Una lista de estudiantes (List<Estudiante>).
Método AgregarEstudiante(Estudiante estudiante): Para agregar estudiantes a la lista.
Método MostrarEstudiantes(): Para mostrar todos los estudiantes y sus cursos inscritos.
En el método Main:

Crear instancias de Curso.
Crear instancias de Estudiante y agregar cursos a cada estudiante.
Agregar estos estudiantes a la lista en la clase GestorEstudiantes.
Llamar al método MostrarEstudiantes() para mostrar la información de todos los estudiantes y los cursos en los que están inscritos.
*/

using System;
using System.Collections.Generic;

class Curso
{
    public string nombre { get; set; }
    public string codigoAlumno { get; set; }
    public int creditosAlumno { get; set; }

    public Curso(string nombre, string codigoAlumno, int creditosAlumno)
    {
        this.nombre = nombre;
        this.codigoAlumno = codigoAlumno;
        this.creditosAlumno = creditosAlumno;
    }

    public string MostrarDetalles() // Metodo que muestra los detalles del curso
    {
        return $"Nombre: {nombre} , codigo: {codigoAlumno} , creditos alumno: {creditosAlumno}";
    }
}

class Estudiante
{
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string matricula { get; set; }
    public List<Curso> Cursos { get; set; }

    // Constructor
    public Estudiante(string nombre, string apellido, string matricula)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.matricula = matricula;
        Cursos = new List<Curso>(); // Inicializa la lista de cursos
    }

    // Metodo AgregarCurso
    public void AgregarCurso(Curso cursoAgregar)
    {
        Cursos.Add(cursoAgregar);
    }

    // Metodo para mostrar todos los cursos en los que esta inscrito el Estudiante actual.
    public void MostrarCursos()
    {
        foreach (var curso in Cursos)
        {
            Console.WriteLine(curso.MostrarDetalles());
        }
    }
}

class GestorDeEstudiantes
{
    public List<Estudiante> Estudiantes;

    // Constructor
    public GestorDeEstudiantes()
    {
        Estudiantes = new List<Estudiante>(); // Inicializa la lista de estudiantes
    }

    // Metodo Agregar estudiantes a una lista
    public void AgregarEstudiantes(Estudiante estudianteAgregar)
    {
        Estudiantes.Add(estudianteAgregar);
    }

    // Metodo para mostrar Estudiantes 
    public void MostrarEstudiantes()
    {
        foreach (var estudiante in Estudiantes) // Recorrer la lista de estudiantes
        {
            Console.WriteLine($"{estudiante.nombre} {estudiante.apellido} ({estudiante.matricula})");
            estudiante.MostrarCursos();
            Console.WriteLine(); // Línea en blanco para separar entre estudiantes
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Curso cursoA = new Curso("CursoA2", "2345", 500);
            Curso cursoB = new Curso("CursoAB", "5345", 400);

            Estudiante David = new Estudiante("David", "Acosta", "4564");
            David.AgregarCurso(cursoA);
            David.AgregarCurso(cursoB);

            Estudiante Carlos = new Estudiante("Carlos", "Rodriguez", "777");
            Carlos.AgregarCurso(cursoA);

            GestorDeEstudiantes listaA = new GestorDeEstudiantes();

            listaA.AgregarEstudiantes(David);
            listaA.AgregarEstudiantes(Carlos);

            listaA.MostrarEstudiantes();
        }
        catch (Exception ex)
        {
            // Mostrar el mensaje de la excepción
            Console.WriteLine($"Se produjo una excepción: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }
}
