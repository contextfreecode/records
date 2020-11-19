#[derive(Debug)]
struct Request<'a> {
    url: &'a str,
    timeout_seconds: Option<f64>,  // No Hash
}

fn main() {
    let request = Request {
        url: "https://rescue.org/",
        timeout_seconds: None,
    };
    dbg!(&request);
    let timeout_request = Request {
        timeout_seconds: Some(30.0),
        ..request
    };
    dbg!(&timeout_request);
}
