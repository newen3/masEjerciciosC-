// See https://aka.ms/new-console-template for more information

/*
Ejercicio 2: Sistema de Empleados (Herencia y Polimorfismo)
Crea una clase base Empleado con:

Propiedades: nombre, apellido, salario.
Método: CalcularSalario que retorne el salario.
Crea una clase derivada EmpleadoPorHora que herede de Empleado y agregue una propiedad horasTrabajadas, y un método que calcule el salario basado en las horas trabajadas.

Crea otra clase derivada EmpleadoFijo que calcule el salario con un bono fijo.

En el método Main, crea instancias de ambas clases y muestra los salarios calculados.
*/



public class Empleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public decimal Salario { get; set; }


    // Constructor de la clase Empleado
    public Empleado(string nombre, string apellido, decimal salario)
    {
        Nombre = nombre;
        Apellido = apellido;
        Salario = salario;
    }


    //Metodo calcular salario
    public virtual decimal CalcularSalario() //Virtua- para poder hacerle modificaciones en lo que retorna este metodo 
    {
        return Salario;
    }
}


class EmpleadoPorHora : Empleado
{
    public int HorasTrabajadas { get; set; }

    public decimal TarifaPorHora { get; set; }

    public EmpleadoPorHora(string nombre, string apellido, decimal tarifaPorHora, int horasTrabajadas)
       : base(nombre, apellido, 0) //Como heredamos de la clase Empleado debemos llamar a sus propiedades , llamamos en 0 al salario del empleado para no generar conflicos.
    {
        TarifaPorHora = tarifaPorHora;
        HorasTrabajadas = horasTrabajadas;
    }

    public override decimal CalcularSalario() //Con el override aca estamos modificando a nuestro interes lo que devuelve esta funcion
    {
        return TarifaPorHora * HorasTrabajadas; //Esto que devuelve aca seria el valor de la propiedad Salario 
    }
}


class EmpleadoFijo : Empleado
{
    public decimal BonoRecibido { get; set; }


    public EmpleadoFijo (string nombre , string apellido , decimal salario , decimal bonoRecibido) // En este caso recibiremos como parametro tambien un salario fijo y un bono
    : base (nombre , apellido , salario) // Llamamos a las propiedades del empleado nombre , apellido , en este caso se recibe un salario en la clase anterior se pasa como parametro 0
                                         // porque el salario corresponde a la cuenta tarifaHora * horas trabajadas , aqui recibimos un salario estatico.
    {
        BonoRecibido = bonoRecibido;
    }


    public override decimal CalcularSalario ()
    {
        return Salario + BonoRecibido;
    }
}



class Program
{
    static void Main(string[] args)
    {
        EmpleadoPorHora empleadoPorHoraDavid = new EmpleadoPorHora("David", "Acosta", 500.60m, 2);

        EmpleadoFijo empleadoFijoCarlos = new EmpleadoFijo("Carlos", "Gonzales", 100.50m, 50);

        Console.WriteLine(empleadoFijoCarlos.CalcularSalario());
    }
}

