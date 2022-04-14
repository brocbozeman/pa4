const baseUrl = "https://localhost:5001/api/Songs";
var songList = [];
var mySong = {};

function handleOnLoad() {
  allSongsApi = baseUrl;

  fetch(allSongsApi, {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  })
    .then(function (response) {
      return response.json();
    })
    .then(function (json) {
      //song = json;
      let html = ``;

      json.forEach((song) => {
        if (song.favorited == "n") {
          console.log(song.songTitle);
          console.log(song.favorited);
          html += `<div class="card col-md-4 bg-dark text-white">`;
          html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
          html += `<div class="card-img-overlay">`;
          html += `<h5 class="card-title">` + song.songTitle + `</h5>`;
          html += `<button class="button delete" id="${song.songID}" onclick='deleteSong(this.id)'>Delete</button>`;
          html += `<button class="button favorite" id="${song.songID}" onclick="favoriteSong(this.id)">Favorite</button>`;
          html += `</div>`;
          html += `</div>`;
        } else {
          console.log("favorited");
          console.log(song.songTitle);
          html += `<div class="card col-md-4 bg-dark text-white">`;
          html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
          html += `<div class="card-img-overlay">`;
          html += `<h5 class="card-title">` + song.songTitle + `</h5>`;
          html += `<button class="button delete" id="${song.songID}" onclick='deleteSong(this.id)'>Delete</button>`;
          html += `<button class="button favorite" id="${-song.songID}" onclick="favoriteSong(this.id)">Remove Favorite</button>`;
          html += `</div>`;
          html += `</div>`;
        }
      });
      document.getElementById("cards2").innerHTML = html;
    });
}

function favoriteSong(id) {
  console.log(id);
  allSongsApi = baseUrl + "/" + id;

  fetch(allSongsApi, {
    method: "PUT",
  }).then((response) => {
    console.log(response);
    handleOnLoad();
  });
}

function addSong() {
  allSongsApi = baseUrl;
  const song = document.getElementById("titleResponse").value;

  fetch(allSongsApi, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      SongTitle: song,
      SongTimeStamp: new Date().toISOString(),
      Deleted: "n",
      Favorited: "n",
    }),
  }).then((response) => {
    console.log(song);
    console.log(response);
    handleOnLoad();
  });
}

function deleteSong(id) {
  console.log(id);
  allSongsApi = baseUrl + "/" + id;

  fetch(allSongsApi, {
    method: "DELETE",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  }).then((response) => {
    console.log(response);
    handleOnLoad();
  });
}

function findSongs() {
  var url = "https://localhost:5001/api/Songs";
  let searchString = document.getElementById("searchSong").value;

  url += searchString;

  console.log(searchString);

  fetch(url)
    .then(function (response) {
      console.log(response);
      return response.json();
    })
    .then(function (json) {
      console.log(json);
      let html = ``;
      json.forEach((song) => {
        console.log(song.title);
        html += `<div class="card col-md-4 bg-dark text-white">`;
        html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
        html += `<div class="card-img-overlay">`;
        html += `<h5 class="card-title">` + song.title + `</h5>`;
        html += `</div>`;
        html += `</div>`;
      });

      if (html === ``) {
        html = "No Songs found :(";
      }
      document.getElementById("searchSongs").innerHTML = html;
    })
    .catch(function (error) {
      console.log(error);
    });
}
