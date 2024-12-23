// See https://aka.ms/new-console-template for more information

/*
 Ejercicio 1: Banco (Encapsulamiento y Métodos)
Crea una clase CuentaBancaria con:

Propiedades: titular (nombre del titular), saldo (monto en la cuenta).
Métodos: Depositar (para agregar dinero), Retirar (para retirar dinero), MostrarSaldo (para mostrar el saldo actual).
La propiedad saldo debe ser privada y no accesible directamente desde fuera de la clase.
Crea un objeto cuenta1 y realiza varias operaciones de depósito y retiro, mostrando el saldo en cada operación.
*/

class CuentaBancaria
{
    public string nombre;
    private double saldo;

    public CuentaBancaria(string nombre, double saldoInicial)
    {
        this.nombre = nombre;
        this.saldo = saldoInicial;
    }


    //Metodo para depositar dinero


    public void DepositarDiner(double cantidadAgregar)
    {
        if (cantidadAgregar > 0)
        {
            saldo += cantidadAgregar; //Se le suma al saldo existente el monto a recibido por parametro.

            Console.WriteLine($"Se han depositado {cantidadAgregar}. Saldo actual: {saldo}");

        }
        else
        {
            Console.WriteLine("El monto ingresado debe ser valido");
        }
    }


    //Metodo retirar dinero


    public void RetirarDinero(double cantidadRetirar)
    {
        if (cantidadRetirar > 0 && cantidadRetirar <= saldo)
        {
            saldo -= cantidadRetirar;

            Console.WriteLine($"Usted retiro: {cantidadRetirar}. su saldo actual es: {saldo}");

        } else
        {
            Console.WriteLine("No posee esta cantidad de dinero o ingrese numero valido");
        }
    }


    //Mostrar saldo ACTUAL.


    public void MostrarSaldo ()
    {
        Console.WriteLine($"Su saldo actual es: {saldo}");
    }
}


class Cuenta1
{
    static void Main(string[] args)
    {
        CuentaBancaria cuentaDavid = new CuentaBancaria("David", 6000);

        cuentaDavid.MostrarSaldo();
    }
}
