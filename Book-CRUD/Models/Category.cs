using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Book_CRUD.Models
{
    /*
        * These are the column names for the category table. 
        * Think of models like, every table is represented in a model.
        * 
        * When the table is created it will make sure "id" is an identity column and "name" is a required field.
        */
    public class Category
    { 
        /*
         *  This class represents the 'Category' entity in the database with properties mapping to the table columns.
         *  It includes the category's ID (primary key), name (required field), display order, and creation date/time with a default value.
         */
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        // setting a defualt title for the field on the application
        [DisplayName("Display Order")]
        // setting the range for the field"DisplayOrder"
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100")]

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
