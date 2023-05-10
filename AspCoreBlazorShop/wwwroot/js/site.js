function getCookie(name) {
    return document.cookie.split(';').find(c => c.trim().startsWith(name + '=')).split('=')[1];
}

function deleteCookie(name) {
    document.cookie = name + "= ; expires = Thu, 01 Jan 1970 00:00:00 GMT";
}
function addCookie(name,value) {
    document.cookie = name + "=" +value;
}
