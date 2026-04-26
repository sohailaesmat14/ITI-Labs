//Self-Documenting Code
// 1. Configuration & Constants
//Meaningful & Intention-Revealing Names
const MIN_PASSWORD_LENGTH = 8; //Avoid Magic Numbers
const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

// 2. Small, Single-Responsibility Functions
function isEmailValid(email) { //Avoid Negative Conditionals where possible
    return EMAIL_REGEX.test(email);
}

function isPasswordStrong(password) {
    return password.length >= MIN_PASSWORD_LENGTH;
}

function isUsernameProvided(username) {
    return username && username.trim() !== '';
}

// 3. Main Validation Function                                   //Default Parameters
function validateUserRegistration({ username, email, password } = {}) {//Object Destructuring
    const validationErrors = [];

    // Guard Clauses (Fail Fast)
    if (!isUsernameProvided(username)) {
        validationErrors.push("Username is required.");
    }

    if (!isEmailValid(email)) {//Encapsulate Conditionals
        validationErrors.push("Invalid email format.");
    }

    if (!isPasswordStrong(password)) {
        validationErrors.push(`Password must be at least ${MIN_PASSWORD_LENGTH} characters long.`);
    }

    // 4. Consistent Return
    return {
        isValid: validationErrors.length === 0,
        errors: validationErrors
    };
}

const newUserData = {
    username: "Suhaila",
    email: "suhaila@example.com",
    password: "securePassword123"
};

const result = validateUserRegistration(newUserData);
console.log(result);