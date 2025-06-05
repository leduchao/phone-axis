import Content from "./Content";
import Footer from "./Footer";
import Header from "./Header";

function MainLayout() {
  return (
    <div style={{ height: "" }}>
      <Header></Header>
      <Content></Content>
      <Footer></Footer>
    </div>
  );
}

export default MainLayout;
