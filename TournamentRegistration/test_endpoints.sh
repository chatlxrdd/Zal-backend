#!/bin/bash

# Funkcja do sprawdzania, czy narzędzie jq jest zainstalowane
check_jq_installed() {
    if ! command -v jq &> /dev/null; then
        echo "jq could not be found. Please install jq."
        exit 1
    fi
}

# Funkcja do rejestrowania nowego użytkownika
register_user() {
    echo "Registering a new user..."
    curl -X POST "http://localhost:5291/api/Auth/register" -H "accept: text/plain" -H "Content-Type: application/json" -d "{ \"username\": \"admin\", \"password\": \"admin\", \"role\": \"Admin\"}"
    echo
}

# Funkcja do logowania użytkownika i pobierania tokenu JWT
login_user() {
    echo "Logging in to get JWT token..."
    TOKEN=$(curl -X POST "http://localhost:5291/api/Auth/login" -H "accept: text/plain" -H "Content-Type: application/json" -d "{ \"username\": \"admin\", \"password\": \"admin\"}" | jq -r .token)
    echo "Token: $TOKEN"
    echo
}

# Funkcja do testowania endpointu GET /api/user
test_get_users() {
    echo "Testing GET /api/user..."
    curl -X GET "http://localhost:5291/api/User" -H "accept: text/plain" -H "Authorization: Bearer $TOKEN"
    echo
}

# Funkcja do testowania endpointu POST /api/user
test_post_user() {
    echo "Testing POST /api/user..."
    curl -X POST "http://localhost:5291/api/User" -H "accept: text/plain" -H "Content-Type: application/json" -H "Authorization: Bearer $TOKEN" -d "{ \"username\": \"newuser\", \"password\": \"password\", \"role\": \"User\"}"
    echo
}

# Funkcja do testowania endpointu GET /api/tournament
test_get_tournaments() {
    echo "Testing GET /api/tournament..."
    curl -X GET "http://localhost:5291/api/Tournament" -H "accept: text/plain" -H "Authorization: Bearer $TOKEN"
    echo
}

# Funkcja do testowania endpointu POST /api/tournament
test_post_tournament() {
    echo "Testing POST /api/tournament..."
    curl -X POST "http://localhost:5291/api/Tournament" -H "accept: text/plain" -H "Content-Type: application/json" -H "Authorization: Bearer $TOKEN" -d "{ \"name\": \"New Tournament\", \"date\": \"2024-06-10T00:00:00\"}"
    echo
}

# Główna funkcja uruchamiająca wszystkie testy
run_tests() {
    check_jq_installed
    register_user
    login_user
    test_get_users
    test_post_user
    test_get_tournaments
    test_post_tournament
}

# Uruchomienie testów
run_tests
