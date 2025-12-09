# dapr10

see config.yaml

run the aspire apphost project. 

navigate to the aspire dashboard http://localhost:15064/

navigate to the blazor frontend weather page: http://localhost:5234/weather

frontend metrics are here: http://localhost:9091/metrics

backend metrics are here: http://localhost:9092/metrics

you should observe backend metrics such as:
`
dapr_http_server_latency_bucket{app_id="webfrontend",method="PUT",path="//v1.0/actors/WeatherActor/03f81ef4-1b42-4ec5-996e-97d8e022ddcb/method/GetWeatherAsync",status="200",le="16"} 0
`
