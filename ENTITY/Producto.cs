namespace ENTITY
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public string Descripcion { get; set; }
        public float Ganancia { get; set; }


        public void CalcularGanancia()
        {
            Ganancia = (Cantidad * PrecioVenta) - (Cantidad * PrecioCompra);
        }

    }
}
