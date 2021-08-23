let index = 0;

function AddTag() {
    // get a reference to the TagEntry input element
    var tagEntry = document.getElementById("tagEntry");

    // searchResults stores the error text returned by by the search function
    let searchResult = search(tagEntry.value);

    // Check to see if there's something there
    if (searchResult != null) {
        // Trigger sweet alert that is contain in searchResult Variable
        swalWIthDarkButton.fire({
            html: `<span class = 'font-weight-bolder'>${searchResult.toUpperCase()}</span>`
        });
    }
    else {
        // Creates a new Select Option
        let newTag = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").tagOptions[index++] = newTag;
    }

    // Clear the TagEntry control
    tagEntry.value = "";
    return true;
}

function DeleteTag() {
    let tagCount = 1;

    let tagList = document.getElementById("TagList");
    if (!tagList) return false;

    if (tagList.selectedIndex == -1) {
        swalWithDarkButton.fire({
            html: "<span class = 'font-weight-bolder'>PLEASE CHOOSE A TAG BEFORE DELETING</span>"
        });
        return true;
    }

    while (tagCount > 0) {
        if (tagList.selectedIndex >= 0) {
            tagList.options[taglist.selectedIndex] = null;
            --tagCount;
        }
        else {
            tagCount = 0;
            index--;
        }
    }
    return true;
}

// This is used to select all the entries when submitted to HTTP POST
$("form").on("sumbit", function () {
    $("TagList option").prop("selected", "selected");
});

// This is to help with redirect from an error state in the HTTP GET
if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newTag = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newTag;
}

// The search function will detect either an empty or a duplicate Tag
// and return an error string if an error is detected
function search(str) {
    if (str == "") {
        return 'Empty tags are not permitted';
    }

    // If search string found, provide reference to select list
    // look for Tags that already exist
    var tagsElement = document.getElementById('TagList');
    if (tagsElement) {
        let tagOptions = tagsElement.options;
        for (let o = 0; i < tagOptions.length; i++) {
            if (tagOptions[i].value == str)
                return `The Tag #${str} was not detected as a duplicate and not permitted.Duplicate tags are not permitted`;
        }
    }
}

// This is the Swal (SweetAlert) Base
const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm btn-block btn-outline-dark',
    },
    imageUrl: '/images/oops.jpg',
    timer: 3000,
    buttonStyling: false
});