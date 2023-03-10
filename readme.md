# About

Repository contains simple ASP.NET WebApi containing 2 endpoints. One of the endpoints is going to always return an exception while second one is going to return correct response every time.

Aim of this repository is to measure difference in response times during stresstest for those 2 endpoints.

# Benchmark results

Benchmark was run on the same machine as server handling results which skewed results, however it is still going to show that request that ends with exception is going to take few times longer to process than successfull one.



## 500 users - exception flow - 100 iterations

|Label       |# Samples|Average|Min|Max  |Std. Dev.|Error % |Throughput|Received KB/sec|Sent KB/sec|Avg. Bytes|
|------------|---------|-------|---|-----|---------|--------|----------|---------------|-----------|----------|
|HTTP Request|50000    |3495   |22 |28305|2978.26  |100.000%|131.49866 |49.57          |18.49      |386.0     |
|TOTAL       |50000    |3495   |22 |28305|2978.26  |100.000%|131.49866 |49.57          |18.49      |386.0     |


## 10 users - exception flow - 100 iterations

|Label       |# Samples|Average|Min|Max|Std. Dev.|Error % |Throughput|Received KB/sec|Sent KB/sec|Avg. Bytes|
|------------|---------|-------|---|---|---------|--------|----------|---------------|-----------|----------|
|HTTP Request|1000     |121    |17 |290|51.80    |100.000%|76.76954  |28.94          |10.80      |386.0     |
|TOTAL       |1000     |121    |17 |290|51.80    |100.000%|76.76954  |28.94          |10.80      |386.0     |


## 500 users - correct flow - 1000 iterations

|Label       |# Samples|Average|Min|Max|Std. Dev.|Error % |Throughput|Received KB/sec|Sent KB/sec|Avg. Bytes|
|------------|---------|-------|---|---|---------|--------|----------|---------------|-----------|----------|
|HTTP Request|500000   |700    |4  |25722|977.42   |0.000%  |673.49501 |434.90         |93.39      |661.2     |
|TOTAL       |500000   |700    |4  |25722|977.42   |0.000%  |673.49501 |434.90         |93.39      |661.2     |


## 10 users - correct flow - 1000 iterations

|Label       |# Samples|Average|Min|Max|Std. Dev.|Error % |Throughput|Received KB/sec|Sent KB/sec|Avg. Bytes|
|------------|---------|-------|---|---|---------|--------|----------|---------------|-----------|----------|
|HTTP Request|10000    |24     |4  |104|14.19    |0.000%  |398.64461 |257.47         |55.28      |661.4     |
|TOTAL       |10000    |24     |4  |104|14.19    |0.000%  |398.64461 |257.47         |55.28      |661.4     |


[Csv to markdown](https://www.convertcsv.com/csv-to-markdown.htm) was used to generate above tables