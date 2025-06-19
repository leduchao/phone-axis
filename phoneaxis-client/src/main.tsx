// import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import SignIn from "./pages/auth/SignIn.tsx";
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import SignUp from "./pages/auth/SignUp.tsx";
import { ROUTES } from "./routes.ts";

createRoot(document.getElementById("root")!).render(
  // <StrictMode>
  <BrowserRouter>
    <Routes>
      <Route path={ROUTES.Home} element={<App />} />
      <Route path={ROUTES.SignIn} element={<SignIn />} />
      <Route path={ROUTES.SignUp} element={<SignUp />} />
    </Routes>
  </BrowserRouter>
  // {/* </StrictMode> */}
);
