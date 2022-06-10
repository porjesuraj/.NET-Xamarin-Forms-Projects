using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Convertors;
using Xamarin.Forms;
namespace ToDo.Test
{
   
   public class BoolToTextDecorationConverterTests
    {

        [Test]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            //Arrange
            var converter = new BoolToTextDecorationConvertor();
            // Act 
            var result = converter.Convert(true,null,null,null);

            //Assert
         

            Assert.That((TextDecorations)result, Is.EqualTo(TextDecorations.Strikethrough));


        }



        [Test]
        public void Convert_returns_none_when_item_is_not_completed()
        {
            //Arrange
            var converter = new BoolToTextDecorationConvertor();
            // Act 
            var result = converter.Convert(false, null, null, null);

            //Assert


            Assert.That((TextDecorations)result, Is.EqualTo(TextDecorations.None));


        }







    }
}
