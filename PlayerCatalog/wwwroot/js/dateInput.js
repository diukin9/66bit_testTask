function typeData() {
    let oldObject = document.getElementById('birthdate');
    let newObject = document.createElement('input');
    newObject.name = 'Birthdate';
    newObject.id = 'birthdate';
    newObject.type = 'date';
    newObject.classList.add('form-control');
    newObject.max = Date.now.toString('yyyy-MM-dd');
    oldObject.parentNode.replaceChild(newObject, oldObject);
}