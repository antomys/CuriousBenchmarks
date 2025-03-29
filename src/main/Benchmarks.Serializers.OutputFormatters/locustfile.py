from locust import FastHttpUser, between, task
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


class Main(FastHttpUser):
    wait_time = between(0.5, 2.5)
    json_headers = {"accept": "application/json", "Content-Type": "application/json"}
    proto_headers = {"accept": "application/protobuf", "Content-Type": "application/protobuf"}
    msgpack_headers = {"accept": "application/x-msgpack", "Content-Type": "application/x-msgpack"}
    mempack_headers = {"accept": "application/x-memorypack", "Content-Type": "application/x-memorypack"}

    def on_start(self):
        self.client.trust_env = True
        self.client.verify = False

    @task
    def serialize_simple_100(self):
        with self.client.get(
                url="/serialize/simple/100",
                catch_response=True,
                verify=False,
                headers=self.json_headers) as response:
            if response.status_code == 200:
                response.success()
    @task
    def deserialize_simple_100(self):
        with self.client.get(
                url="/deserialize/simple/100",
                catch_response=True,
                verify=False,
                headers=self.json_headers) as response:
            if response.status_code == 200:
                response.success()
