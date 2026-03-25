const countriesContainer = document.querySelector('.countries');
const btn = document.getElementById('searchBtn');
const input = document.getElementById('countryInput');

const renderCountry = function (data, className = '') {
  const html = `
    <article class="country-wrapper">
      ${className === 'neighbor' ? '<div class="neighbor-label">Neighbour Country</div>' : ''}
      <article class="country ${className}">
        <img class="country__img" src="${data.flag}" />
        <div class="country__data">
          <h3 class="country__name">${data.name}</h3>
          <h4 class="country__region">${data.region}</h4>
          <p class="country__row"><span>👫</span>${(data.population / 1000000).toFixed(1)} M People</p>
          <p class="country__row"><span>🗣️</span>${data.languages[0].name}</p>
          <p class="country__row"><span>💰</span>${data.currencies[0].name}</p>
        </div>
      </article>
    </article>
  `;
  countriesContainer.insertAdjacentHTML('beforeend', html);
};

const getCountryData = function (country) {
  countriesContainer.innerHTML = '';
  
  fetch(`https://restcountries.com/v2/name/${country}`)
    .then((response) => {
      if (!response.ok) throw new Error('Country not found');
      return response.json();
    })
    .then((data) => {
      renderCountry(data[0]);
      const neighbor = data[0].borders?.[0];
      if (!neighbor) throw new Error('No neighbor found');
      return fetch(`https://restcountries.com/v2/alpha/${neighbor}`);
    })
    .then((response) => {
      if (!response.ok) throw new Error('Neighbor not found');
      return response.json();
    })
    .then((data) => renderCountry(data, 'neighbor'))
    .catch((err) => {
      alert(err.message);
    });
};

btn.addEventListener('click', function() {
  const countryName = input.value.trim();
  if (countryName) {
    getCountryData(countryName);
  }
});

input.addEventListener('keypress', function(e) {
  if (e.key === 'Enter') {
    btn.click();
  }
});