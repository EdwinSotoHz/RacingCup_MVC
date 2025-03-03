function openModal(row, col, category) {
    // Obtener los datos del equipo
    var team = @Json.Serialize(Model.JuniorTeams); // Cambiar a SeniorTeams para la vista Senior
    team = team[row][col];

    // Mostrar los datos en la ventana modal
    document.getElementById("modalTeamName").innerText = team.name;
    document.getElementById("modalTeamElements").innerText = team.elements;
    document.getElementById("modalTeamSchool").innerText = team.school;
    document.getElementById("modalTeamCategory").innerText = team.category;
    document.getElementById("modalTeamBestTime").innerText = team.bestTime;
    document.getElementById("modalTeamStatus").innerText = team.status ? "Activo" : "Inactivo";

    // Asignar valores a los campos ocultos
    document.getElementById("modalRow").value = row;
    document.getElementById("modalCol").value = col;
    document.getElementById("modalCategory").value = category;

    document.getElementById("modalRowLoser").value = row;
    document.getElementById("modalColLoser").value = col;
    document.getElementById("modalCategoryLoser").value = category;

    // Mostrar la ventana modal
    document.getElementById("teamModal").style.display = "block";
}

function closeModal() {
    // Ocultar la ventana modal
    document.getElementById("teamModal").style.display = "none";
}