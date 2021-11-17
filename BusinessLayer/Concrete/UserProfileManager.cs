using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    
    public class UserProfileManager
    {
        Repository<Author> repouserprofil = new Repository<Author>();
        Repository<Blog> repouserblog= new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouserprofil.List(x => x.Mail == p);


        }

        public List<Blog>GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorID == id);

        }


        public int EditAuthor(Author p)
        {
            Author author = repouserprofil.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AboutShort = p.AboutShort;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repouserprofil.Update(author);

        }

    }
}
