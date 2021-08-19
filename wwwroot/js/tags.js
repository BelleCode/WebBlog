let index = 0;

function AddTag() {
    var tagEntry = document.getElementById("tagEntry");

    // searchResults stores the error text returned by by the search function
    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        swalWIthDarkButton.fire({
            html: `<span class = 'font-weight-bolder'>${searchResult.toUpperCase()}</span>`
        });
    }
    else {
        let newTag = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newTag;
    }
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
function search(str) {
    if (str == "") {
        return 'Empty tags are not permitted';
    }

    var tagsEl = document.getElementById('TagList');
    if (tagsEl) {
        let options = tagsEl.options;
        for (let o = 0; i < options.length; i++) {
            if (options[i].value == str)
                return `Duplicate tags are not permitted`;
        }
    }
}

// This is the Swal (SweetAlert) Base
const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm btn-block btn-outline-dark',
    },
    imageUrl: '/images/profile.png',
    timer: 3000,
    buttonStyling: false
});