#[derive(Clone, Debug)]
struct Request {
    url: String,
    timeout_seconds: Option<f64>,
}

fn main() {
    let request = Request {
        url: "https://rescue.org/".into(),
        timeout_seconds: None,
    };
    dbg!(&request);
    let timeout_request = Request {
        timeout_seconds: Some(30.0),
        ..request.clone()
    };
    dbg!(&timeout_request);
}
