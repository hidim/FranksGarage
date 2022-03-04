import { Container } from "react-bootstrap";

function Footer() {
  return (
      <footer className="border-top footer text-muted">
          <Container>
              &copy; 2022 - Frank's Garage - <a asp-area="" asp-page="/Privacy">Privacy Policy</a>
          </Container>
      </footer>
  );
}

export default Footer;
