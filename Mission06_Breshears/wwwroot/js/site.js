// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// CODE FOR AddMovie.cshtml
// Make sure user enters movies in correct format

/*
document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('form').addEventListener('submit', function (event) {
        var yearInput = document.querySelector('input[name="Year"]');
        var notesInput = document.querySelector('input[name="Notes"]');

        if (yearInput.value < 1900 || yearInput.value > 9999) {
            alert('Year must be between 1900 and 9999.');
            event.preventDefault(); // Prevent form submission
        }

        if (notesInput.value.length > 25) {
            alert('Notes must not exceed 25 characters.');
            event.preventDefault(); // Prevent form submission
        }
    });
});
test
*/

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('form').addEventListener('submit', function (event) {
        var categoryInput = document.querySelector('input[name="Category"]');
        var titleInput = document.querySelector('input[name="Title"]');
        var yearInput = document.querySelector('input[name="Year"]');
        var directorInput = document.querySelector('input[name="Director"]');
        var ratingInput = document.querySelector('select[name="Rating"]');
        var notesInput = document.querySelector('input[name="Notes"]');

        // Check if required fields are empty
        if (!categoryInput.value || !titleInput.value || !yearInput.value || !directorInput.value || !ratingInput.value) {
            alert('Please fill in all required fields (Category, Title, Year, Director, Rating).');
            event.preventDefault(); // Prevent form submission
        }

        // Check if year is in the correct format
        if (yearInput.value < 1900 || yearInput.value > 9999 || isNaN(yearInput.value)) {
            alert('Year must be a four-digit number between 1900 and 9999.');
            event.preventDefault(); // Prevent form submission
        }

        // Check if notes exceed 25 characters
        if (notesInput.value.length > 25) {
            alert('Notes must not exceed 25 characters.');
            event.preventDefault(); // Prevent form submission
        }
    });
});