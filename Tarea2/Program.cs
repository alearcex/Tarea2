//Tarea #2 Programación 2
//Alessandro Arce Chaves
//Pasé más tiempo del que me gustaría contando para que todo quedara alineado

//variables que no necesitan reiniciarse cada que se repite el do while
int opcion = 1;
int operarios = 0;
int tecnicos = 0;
int profesionales = 0;
double netoOperarios = 0;
double netoTecnicos = 0;
double netoProfesionales = 0;

do
{
    //variables que se reinician cada que inicia el ciclo
    string nombre = "";
    int cedula = 0;
    string tipoEmpleado = "";
    int horas = 0;
    double precio = 0;
    double salarioOrdinario = 0;
    double salarioBruto = 0;
    double salarioNeto = 0;
    double porcAumento = 0;
    double aumento = 0;
    double ccss = 0;

    //Se imprime formulario principal y se toman los datos
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("----      Sistema de Aumentos Salariales       ----");
    Console.WriteLine("---------------------------------------------------");

    Console.WriteLine("Por favor, ingrese los siguientes datos...");
    Console.WriteLine("- Nombre del empleado:");
    nombre = Console.ReadLine();

    Console.WriteLine("- Cédula:");
    cedula = int.Parse(Console.ReadLine());

    Console.WriteLine("- Tipo de empleado:");
    Console.WriteLine("1. Operador");
    Console.WriteLine("2. Técnico");
    Console.WriteLine("3. Profesional");
    tipoEmpleado = Console.ReadLine();

    Console.WriteLine("- Cantidad de horas laboradas:");
    horas = int.Parse(Console.ReadLine());

    Console.WriteLine("- Precio por hora:");
    precio = double.Parse(Console.ReadLine());

    // Valida cuál es el tipo seleccionado
    if (tipoEmpleado == "1")
    {
        porcAumento = 0.15; //% de aumento que se realizará
        tipoEmpleado = "Operario"; // el tipo pasa de número a el nombre
        operarios += 1; // se agrega al contador del tipo para el cálculo del promedio
    }
    else if (tipoEmpleado == "2")
    {
        porcAumento = 0.10;
        tipoEmpleado = "Técnico";
        tecnicos += 1;
    }
    else if (tipoEmpleado == "3") {
        porcAumento = 0.5;
        tipoEmpleado = "Profesional";
        profesionales += 1;
    }

    //Se realizan los cálculos salariales
    salarioOrdinario = precio * horas;
    aumento = salarioOrdinario * porcAumento;
    salarioBruto = salarioOrdinario + aumento;
    ccss = (salarioBruto * (9.17 / 100));
    salarioNeto = salarioBruto - ccss;

    //se van sumando los salarios netos para calcular el promedio
    if (tipoEmpleado == "Operario")
    {
        netoOperarios += salarioNeto;
    }
    else if (tipoEmpleado == "Técnico")
    {
        netoTecnicos += salarioNeto;

    }
    else if (tipoEmpleado == "Profesional")
    {
        netoProfesionales += salarioNeto;
    }

    //Se imprime un resumen de los datos ingresados
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("----   Sistema de Aumentos Salariales    ----");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Nombre del empleado: {0,22}", nombre);
    Console.WriteLine("Cédula: {0,35}", cedula);
    Console.WriteLine("Tipo de empleado: {0, 25}", tipoEmpleado);
    Console.WriteLine("Salario por hora: {0, 25}", precio.ToString("0.##"));
    Console.WriteLine("Cantidad de horas laboradas: {0, 14}", horas);
    Console.WriteLine("Salario ordinario: {0, 24}", salarioOrdinario.ToString("0.##"));
    Console.WriteLine("Aumento ({0}%): {1, 28}", porcAumento * 100, aumento.ToString("0.##"));
    Console.WriteLine("Salario bruto: {0, 28}", salarioBruto.ToString("0.##"));
    Console.WriteLine("Deducción CCSS (9.17%): {0,19}", ccss.ToString("0.##"));
    Console.WriteLine("Salario Neto: {0, 29}", salarioNeto.ToString("0.##"));
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("¿Desea registrar otro aumento?");
    Console.WriteLine(" 1. Si");
    Console.WriteLine(" 2. No");
    Console.WriteLine("---------------------------------------------");
    //Se lee lo que el usuario haya decidido
    opcion = int.Parse(Console.ReadLine());
    Console.Clear();

} while (opcion > 0 && opcion < 2);

//Se imprimen las estaísticas finales
Console.Clear();
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("-----       Sistema de Aumentos Salariales        -----");
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("Resumen de estadísticas generales");
Console.WriteLine("-------------------------------------------------------");

// esto para que no se divida el salario entre 0
var promedio = (operarios == 0) ? 0 : netoOperarios / operarios; 
Console.WriteLine("Operarios");
Console.WriteLine("Cantidad: {0, 45}", operarios);
Console.WriteLine("Total de salarios netos: {0, 30}", netoOperarios.ToString("0.##"));
Console.WriteLine("Salario neto promedio: {0, 32}", promedio.ToString("0.##"));
Console.WriteLine("");
promedio = (tecnicos == 0) ? 0 : netoTecnicos / tecnicos;
Console.WriteLine("Tecnicos");
Console.WriteLine("Cantidad: {0, 45}", tecnicos);
Console.WriteLine("Total de salarios netos: {0, 30}", netoTecnicos.ToString("0.##"));
Console.WriteLine("Salario neto promedio: {0, 32}", promedio.ToString("0.##"));
Console.WriteLine("");
promedio = (profesionales == 0) ? 0 : netoProfesionales / profesionales;
Console.WriteLine("Profesionales");
Console.WriteLine("Cantidad: {0, 45}", profesionales);
Console.WriteLine("Total de salarios netos: {0, 30}", netoProfesionales.ToString("0.##"));
Console.WriteLine("Salario neto promedio: {0, 32}", promedio.ToString("0.##"));
Console.WriteLine("-------------------------------------------------------");

