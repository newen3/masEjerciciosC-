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
class Curso
{
    public string nombre ;
    public string codigo ;
    public int creditos ;

    public Curso(string nombre, string codigo, int creditos)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.creditos = creditos;
    }

    public void MostrarDetalles() // Metodo que muestra los detalles del curso
    {
        Console.WriteLine("DETALLES DEL CURSO: ");
        Console.WriteLine($"Nombre del curso: {nombre}");
        Console.WriteLine($"Codigo: {codigo}");
        Console.WriteLine($"creditos: {creditos}");
    }
}

class Estudiante
{
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string matricula { get; set; }
    public List<Curso> Cursos = new List<Curso>();

    // Constructor
    public Estudiante(string nombre, string apellido, string matricula)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.matricula = matricula;
    }

    //agrega un curso a la lista cursos si el curso a agregar no se encuentra en la lista.
    public void AgregarCurso(Curso cursoAgregar)
    {
        if(BuscarEnLaLista(cursoAgregar) == null)
        {
            Cursos.Add(cursoAgregar);
            Console.WriteLine($"el alumno {nombre} se a inscripto a el curso {cursoAgregar.nombre}");
        }
        else
        {
            Console.WriteLine($"el alumno {nombre} ya esta inscripto en el curso {cursoAgregar.nombre}");
        }
    }

    //busca un elemento tipo Curso dentro de la lista cursos , si lo encuentra lo devuelve si no devuelve null.
    public Curso BuscarEnLaLista(Curso cursoABuscar)
    {
        foreach (var curso in Cursos)
        {
            if(cursoABuscar == curso)
            {
                return curso;
            }
        }
        return null;
    }


    //Metodo para mostrar todos los cursos en los que esta inscrito el Estudiante actual .
    //en este metodo usaste Console.WriteLine(curso.MostrarDetalles()) pero solo tenes que mostrar los nombres.
    //por la consigna que vi solo tenias que mostrar la lista completa de cursos(nombre de cursos) en los que esta inscripto un Estudiante(estudiante actual);
    public void MostrarCursos()
    {
        Console.WriteLine($"LISTA DE CURSOS A LOS QUE ESTA INSCRIPTO {nombre}: ");
        foreach (var curso in Cursos)
        {
            Console.WriteLine(curso.nombre);
        }
    }
}

class GestorDeEstudiantes
{
    public List<Estudiante> Estudiantes = new List<Estudiante>();

    // Metodo Agregar estudiantes a una lista
    public void AgregarEstudiante(Estudiante estudianteAgregar)
    {
        if (BuscarEnLaLista(estudianteAgregar) == null)
        {
            Estudiantes.Add(estudianteAgregar);
            Console.WriteLine($"se agrego el estudiante {estudianteAgregar.nombre} a la lista");
        }
        else
        {
            Console.WriteLine($"el estudiante {estudianteAgregar.nombre} ya esta en la lista");
        }
    }

    public Estudiante BuscarEnLaLista(Estudiante estudianteABuscar)
    {
        foreach (var estudiante in Estudiantes)
        {
            if(estudianteABuscar == estudiante)
            {
                return estudiante;
            }
        }
        return null;
    }


    // Metodo para mostrar Estudiantes y los cursos en los que esta inscripto.
    public void MostrarEstudiantes()
    {
        foreach (var estudiante in Estudiantes) // Recorrer la lista de estudiantes
        {
            Console.WriteLine($"Nombre: {estudiante.nombre}, Apellido: {estudiante.apellido}, Matricula: {estudiante.matricula}");
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
