using ListaDeLaCompra;

List<Cesta> cesta = new List<Cesta>();
int cantidadArticulos = 0;
bool esNumeroValido = false;

do
{
    Console.Write("¿Cuántos artículos quieres comprar?: ");
    string entrada = Console.ReadLine() ?? "";

    if (int.TryParse(entrada, out cantidadArticulos) && !string.IsNullOrEmpty(entrada) && cantidadArticulos > 0)
    {
        esNumeroValido = true;
    }
    else
    {
        Console.WriteLine("Error: Debe ingresar un número entero válido mayor a cero.");
    }
} while (!esNumeroValido);


for (int i = 0; i < cantidadArticulos; i++)
{
    Cesta articulo = new Cesta();

    Console.WriteLine($"Artículo {i + 1}:");
    articulo.Articulo = Console.ReadLine();


    do
    {
        Console.Write("Cantidad: ");
        int cantidadProducto = 0;
        articulo.Cantidad = cantidadProducto; // Reiniciar cantidad para evitar valores anteriores
        string entrada = Console.ReadLine() ?? "";

        if (int.TryParse(entrada, out cantidadProducto) && !string.IsNullOrEmpty(entrada) && cantidadProducto > 0)
        {

            esNumeroValido = true;
            articulo.Cantidad = cantidadProducto; // Asignar la cantidad válida al artículo
        }
        else
        {
            esNumeroValido = false;
            Console.WriteLine("Error: Debe ingresar un número entero válido mayor a cero.");
        }
    } while (!esNumeroValido);

    do
    {
        Console.Write("Precio por unidad: ");
        decimal precioProducto = 0;
        string entrada = Console.ReadLine() ?? "";

        if (decimal.TryParse(entrada, out precioProducto) && !string.IsNullOrEmpty(entrada) && precioProducto > 0)
        {

            esNumeroValido = true;
            articulo.Precio = precioProducto; // Asignar el precio válido al artículo
        }
        else
        {
            esNumeroValido = false;
            Console.WriteLine("Error: Debe ingresar un número entero válido mayor a cero.");
        }
    } while (!esNumeroValido);

    articulo.Total = articulo.Cantidad * articulo.Precio;

    cesta.Add(articulo);
}

decimal totalCompra = 0;
Console.WriteLine("\nLista de la compra:");
foreach (var item in cesta)
{
    Console.WriteLine($"{item.Articulo} - Cantidad: {item.Cantidad}, Precio por unidad: {item.Precio}, Total: {item.Total}");
    totalCompra += item.Total;
}

Console.WriteLine($"\nTotal de la compra: {totalCompra:F2}");

namespace ListaDeLaCompra
{
    
    public class Cesta
    {
        public string? Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Total { get; set; }


        public Cesta()
        {
            Total = new decimal();
        }
    }
}
