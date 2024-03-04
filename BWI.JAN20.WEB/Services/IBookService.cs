using BWI.JAN20.WEB.Models;

namespace BWI.JAN20.WEB.Services
{
    public interface IBookService
    {
        /*
         contains signature of method
         abstract form of any class
         */
        List<BookModel> GetBooks();
        int SaveBook(BookModel model);
        int DeleteBook(int id);
        int UpdateBook(BookModel model);
        BookModel? GetBook(int id);

        void AnotherPublicMethod();
    }
}
