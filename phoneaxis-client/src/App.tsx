import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import { ROUTES } from "./routes";
import SignIn from "./pages/auth/SignIn";
import SignUp from "./pages/auth/SignUp";
import ProductsPage from "./pages/ProductsPage";
import NotFoundPage from "./pages/NotFoundPage";
import HomePage from "./pages/HomePage";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={ROUTES.SignIn} element={<SignIn />} />
        <Route path={ROUTES.SignUp} element={<SignUp />} />
        <Route path={ROUTES.Home} element={<MainLayout />}>
          <Route path={ROUTES.Home} element={<HomePage />} />
          <Route path={ROUTES.Products} element={<ProductsPage />} />
          {/* <Route path={ROUTES.Pricing} element={<PricingPage />} />
          <Route path={ROUTES.Blogs} element={<BlogPage />} /> */}
          <Route path={ROUTES.NotFound} element={<NotFoundPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default App;
