# TryUpdateModelAsyncProblem

Demo ASP․NET Core 3.1 `TryUpdateModelAsync` Problem

## Run this project

```sh
git clone https://github.com/doggy8088/TryUpdateModelAsyncProblem.git
cd TryUpdateModelAsyncProblem
dotnet run
```

## Test

1. Request to the API using `application/json` content-type. **It's not working.**

    ```sh
    curl --location --request POST 'https://localhost:5001/WeatherForecast' --header 'Content-Type: application/json' --data-raw '{"Date": "2019-12-01", "TemperatureC": 1, "Summary": "N/A"}' -k -D -
    ```

2. Request to the API using `application/x-www-form-urlencoded` content-type. **It works perfectly.**

    ```sh
    curl --location --request POST 'https://localhost:5001/WeatherForecast' --header 'Content-Type: application/x-www-form-urlencoded' --data-raw 'Date=2019-12-01&TemperatureC=1&Summary=N/A' -k -D -
    ```
