using BWI.JAN20.WEB.Models;

namespace BWI.JAN20.WEB.Services
{
    public class BookService2 : IBookService
    {
        public BookService2(BWIJAN20WEBContext context)
        {
            
        }

        public void AnotherPublicMethod()
        {
            throw new NotImplementedException();
        }

        public int DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public BookModel? GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookModel> GetBooks()
        {
            throw new NotImplementedException();
        }

        public int SaveBook(BookModel model)
        {
            throw new NotImplementedException();
        }

        public int UpdateBook(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
