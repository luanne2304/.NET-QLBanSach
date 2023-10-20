//modal
var modal = document.getElementById("myModal");

//close modal
var close = document.getElementsByClassName("close")[0];
var close_footer = document.getElementsByClassName("close-footer")[0];

function closemd() {
    modal.style.display = "none";
}

//alert
const notifications = document.querySelector(".notifications");
// Object containing details for different types of toasts
const toastDetails = {
    timer: 5000,
    success: {
        icon: 'fa-circle-check',
        text: 'Thao tác thành công!',
    },
    error: {
        icon: 'fa-circle-xmark',
        text: 'Thao tác thất bại!',
    },
    warning: {
        icon: 'fa-triangle-exclamation',
        text: 'Warning: This is a warning toast.',
    },
    info: {
        icon: 'fa-circle-info',
        text: 'Info: This is an information toast.',
    }
}
const removeToast = (toast) => {
    toast.classList.add("hide");
    if (toast.timeoutId) clearTimeout(toast.timeoutId); // Clearing the timeout for the toast
    setTimeout(() => toast.remove(), 500); // Removing the toast after 500ms
}
function alertsuccess(flag) {
    const { icon, text } = toastDetails[flag];
    const toast = document.createElement("li"); // Creating a new 'li' element for the toast
    toast.className = `noti ${flag}`; // Setting the classes for the toast
    // Setting the inner HTML for the toast
    toast.innerHTML = `<div class="column">
                             <i class="fa-solid ${icon}"></i>
                             <span>${text}</span>
                          </div>
                          <i class="fa-solid fa-xmark" onclick="removeToast(this.parentElement)"></i>`;
    notifications.appendChild(toast); // Append the toast to the notification ul
    // Setting a timeout to remove the toast after the specified duration
    toast.timeoutId = setTimeout(() => removeToast(toast), toastDetails.timer);
}

function searchProduct() {
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    var cate = urlParams.get('cate');
    var nameproduct = document.getElementById("find-sach").value;
    if (cate == null) {
        window.location.href = '/Home/ListProduct?name=' + nameproduct;
    }
    else {
        window.location.href = '/Home/ListProduct?cate=' + cate +'&name=' + nameproduct;
    }
}


