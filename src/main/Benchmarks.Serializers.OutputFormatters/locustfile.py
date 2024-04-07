from locust import HttpUser, between, task, tag

class Tests(HttpUser):
    wait_time = between(0.5, 2.5)

    def on_start(self):
        self.client.verify = False

    @task
    def simpleSerialize(self):
        self.client.get(
            url="/serialize/simple/100",
            verify=False,
            headers={"accept": "application/protobuf", "Content-Type": "application/protobuf"})
