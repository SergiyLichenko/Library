# Library
Simulation of library management system

! This application is not fully localized for english users

If you would be a director of the library this program will allow you to manage all your processes

Example of usage:

  1. When you launch this application you will have two options to choose data source
  
     - SQL Database:
     
     ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Login%20SQL.png)
     
     - XML File:
     
      ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Login%20XML.png)
      
  2. So let's choose SQL database and click connect. After connection to the database the authorization window will popup and here you have to put your credentials in order to login into system:
  
      ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Authorization.png)
      
  3. After you input correct credentials and click "Log In" you will see the main window of the program
  
       ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Main%20Window%20Books.png)
       
  4. As a default the tab with books information is selected. But you can also select another tab with articles and magazines
  
       ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Main%20Window%20Magazines%20and%20Articles.png)
       
  5. Currently there is not so many books, articles or magazines in our library so let's add one book by choosing in menu "Book -> Add New Book"
  
      ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Add%20Book.png)
      
  We can add multiple books by clicking "Add Book" and save it with one request by clicking "Save Book"
  
  6. So I have adding three books in my library they appear in the main list:
  
      ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/After%203%20Add.png)
      
  7. But this application was created to manage our books and provide them to our visitors. So let's give one of the books to some visitor. You will have to right click on book and select "Provide book" and this window will appear. Here you can choose the visitor and the copy of the book, however, system manages whether the book copy is available right now or it has been taken by another visitor:
  
       ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Provide%20Book.png)
      
  8. When visitor will read this book and later come back to the library, you can create a record that the book is back in you database:
  
        ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Take%20back%20book.png)
        
  9. If your library is really big you will have a lot of books, articles or magazines so you need somehow to search, and this application provides search functionality as well. You can search by name, author or publisher:
  
        ![alt tag]( https://github.com/SergiyLichenko/Library/blob/master/Docs/Search.png)
        
  10. You can also update your book, magazine or article. Let's update finded book by clicking "Book -> Update Selected Book"
  
        ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Update%20book.png)
        
  11. If you are admin you can also add more users into your library managment system by clicking "Users -> Create New User". And this window will pop up
  
        ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Create%20User.png)
        

There is also functionality for saving all your data into XML file (for example you want to transfer it, so you will not have to transfer entire database), switching between user profiles and all the features which were shown above for books are also availabel for articles and magazines

#
Finally here is the diagram of the database for this application

 ![alt tag](https://github.com/SergiyLichenko/Library/blob/master/Docs/Database%20diagram.png)


       
  
  
      
      
  
  
