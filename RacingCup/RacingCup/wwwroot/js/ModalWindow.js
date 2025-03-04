function openModal(row, col, category, teamCount) {
    // Obtener los datos del equipo desde la variable global
    var team = teamsData[row][col];

    // Mostrar los datos en la ventana modal
    document.getElementById("modalTeamName").innerText = team.name;
    document.getElementById("modalTeamElements").innerText = team.elements;
    document.getElementById("modalTeamSchool").innerText = team.school;
    document.getElementById("modalTeamCategory").innerText = team.category;
    document.getElementById("modalTeamBestTimeInput").value = team.bestTime;
    document.getElementById("modalTeamStatus").innerText = team.status ? "Activo" : "Inactivo";

    // Asignar valores a los campos ocultos
    document.getElementById("modalRow").value = row;
    document.getElementById("modalCol").value = col;
    document.getElementById("modalCategory").value = category;

    document.getElementById("modalRowLoser").value = row;
    document.getElementById("modalColLoser").value = col;
    document.getElementById("modalCategoryLoser").value = category;

    // Mostrar u ocultar la opción "Desclasificar"
    var formSetLoser = document.getElementById("formSetLoser");
    if (teamCount % 2 !== 0 && col === teamCount - 1) {
        formSetLoser.style.display = "inline-block"; // Mostrar si el equipo está solo
    } else {
        formSetLoser.style.display = "none"; // Ocultar si el equipo tiene pareja
    }

    // Mostrar la ventana modal
    document.getElementById("teamModal").style.display = "block";
}

function closeModal() {
    // Ocultar la ventana modal
    document.getElementById("teamModal").style.display = "none";
}

// Función para actualizar el mejor tiempo antes de enviar el formulario
function setBestTime(form) {
    var bestTime = document.getElementById("modalTeamBestTimeInput").value;
    form.querySelector("input[name='bestTime']").value = bestTime;
}
