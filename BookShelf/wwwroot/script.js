document.addEventListener('DOMContentLoaded', function () {
    const createBookButton = document.getElementById('createBookButton');
    const updateBookButton = document.getElementById('updateBookButton');
    const getBooksButton = document.getElementById('getBooksButton');
    const authorInput = document.getElementById('author');
    const nameInput = document.getElementById('name');
    const descriptionInput = document.getElementById('description');
    const categoryInput = document.getElementById('category');

    const authorUpdateInput = document.getElementById('authorUpdate');
    const nameUpdateInput = document.getElementById('nameUpdate');
    const descriptionUpdateInput = document.getElementById('descriptionUpdate');
    const categoryUpdateInput = document.getElementById('categoryUpdate');
   

    createBookButton.addEventListener('click', function () {
        const author = authorInput.value;
        const name = nameInput.value;
        const description = descriptionInput.value;
        const category = parseInt(categoryInput.value);

        const book = {
            author: author,
            name: name,
            description: description,
            category: category
        };
        fetch('/api/Book/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(book)
        })
            .then(response => response.json())
            .then(data => {
                var outputDiv = document.getElementById('output');
                outputDiv.innerHTML = JSON.stringify(data, null, 2);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });
});

getBooksButton.addEventListener('click', function () {
    fetch('/api/Book/all', {
        method: 'GET'
    }).then(response => response.json())
      .then(data => {
          var showBooksDiv = document.getElementById('showBooks');
          showBooksDiv.innerHTML = JSON.stringify(data, null, 2);
        })
        .catch(error => {
            console.error('Error:', error);
        });
})

updateBookButton.addEventListener('click', function () {
    var bookId = document.getElementById('id').value;

    var requestObj = {
        description: document.getElementById('descriptionUpdate').value,
        name: document.getElementById('nameUpdate').value,
        author: document.getElementById('authorUpdate').value,
        category: parseInt(document.getElementById('categoryUpdate').value)
    }
    fetch(`/api/Book/${bookId}/update`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestObj)
    }).then(response => response.json())
     .then(data => {
       
         var updatedBookDiv = document.getElementById('updatedBook');
         updatedBookDiv.innerHTML = JSON.stringify(data, null, 2);
    })
    .catch(error => {
        console.error('Error updating book:', error);
    }); 

})

//var bookId = $("#bookIdInput").val(); // Get the book ID from an input field or another source
//var formData = new FormData();

//formData.append("Name", $("#nameInput").val());
//formData.append("Author", $("#authorInput").val());
//formData.append("Description", $("#descriptionInput").val());
//formData.append("RegistrationTimeStamp", $("#registrationTimeStampInput").val());
//formData.append("Category", $("#categoryInput").val());

//// Construct the URL with the bookId in the query string
//var apiUrl = "/api/books/" + bookId + "/update";

