using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsMiercoles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Iniciamos una instancia de la BD
            using (var db = new BlogContext())
            {
                //Añadimos tres blogs
                db.Blogs.Add(new Blog { Name = "Blog de Cocina" });
                db.Blogs.Add(new Blog { Name = "Blog de Cosina" });
                db.Blogs.Add(new Blog { Name = "Blog de Cusine" });
                db.SaveChanges();

                //Mostramos los blogs
                foreach(var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
                Console.WriteLine("Pulsa una tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}
