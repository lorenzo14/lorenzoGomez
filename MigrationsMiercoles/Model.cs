using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationsMiercoles
{
    //Creamos una clase que hara las veces de base de datos
    public class BlogContext : DbContext
    {
        //Tabla Blogs
        public DbSet<Blog> Blogs { get; set; }

        public BlogContext() : base(@"Data Source=localhost\sqlexpress;Initial Catalog=migrationsMiercoles;Integrated Security=True") { }
    }

    //Clase Blogs
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Url { get; set; }
        public int Rating { get; set; }

        //Lista de posts
        public virtual List<Post> Posts { get; set; }
    }

    //Clase Posts
    public class Post
    {
        //Definimos las claves primarias, y establecemos su orden
        [Key]
        [Column(Order = 1)]
        public int PostId { get; set; }

        [Key]
        [MaxLength(200)]
        [Column(Order = 2)]
        public string Title { get; set; }
        public string Content { get; set; }

        //Blog al que pertenece
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
