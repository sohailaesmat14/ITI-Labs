const countriesContainer = document.querySelector('.countries');
const searchBtn = document.getElementById('searchBtn');
const countryInput = document.getElementById('countryInput');

const renderCountry = function (data) {
    const html = `
    <article class="country-card">
      <img class="country-img" src="${data.flag}" />
      <div class="country-data">
        <h3 class="country-name">${data.name}</h3>
        <h4 class="country-region">${data.region}</h4>
        <p class="country-row">${(data.population / 1000000).toFixed(1)} M People</p>
        <p class="country-row">${data.languages[0].name}</p>
        <p class="country-row">${data.currencies[0].name}</p>
      </div>
    </article>
    `;
    countriesContainer.innerHTML = html;
};

const getCountryData = function (country) {
    fetch(`https://restcountries.com/v2/name/${country}`)
        .then(response => {
            if (!response.ok) throw new Error('Country not found');
            return response.json();
        })
        .then(data => {
            renderCountry(data[0]);
        })
        .catch(err => {
            alert(err.message);
        });
};

searchBtn.addEventListener('click', function () {
    const country = countryInput.value;
    if (country) getCountryData(country);
});

countryInput.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        const country = countryInput.value;
        if (country) getCountryData(country);
    }
});