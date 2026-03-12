console.log("Site script loaded");

// Get an array of all the delete buttons
let deleteButton = document.querySelectorAll("#DeleteButton");

// So you can wire them up with simple confirm dialogs
for (let i = 0; i < deleteButton.length; i++) {
  deleteButton[i].addEventListener("click", function (event) {
    let itemName = event.target.getAttribute("name");
    console.log(itemName);

    let confirmChoice = confirm(
      "Are you sure you want to delete \'" + itemName + "\'?",
    );
    if (!confirmChoice) {
      event.preventDefault();
    }
    console.log(confirmChoice);
    
  });
}
