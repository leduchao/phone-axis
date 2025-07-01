import {
  TextField,
  Typography,
  Box,
  FormControlLabel,
  Checkbox,
  Button,
  Divider,
  Link,
  Card,
  CardContent,
} from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";
import { ROUTES } from "../../routes";
import { useNavigate } from "react-router";
import { authApi } from "../../apis/auth-api";
import { SignInRequest } from "../../models/auth-model";
import { LocalStorageKey } from "../../constants/local-storage";
import { Controller, useForm } from "react-hook-form";

function SignIn() {
  const navigate = useNavigate();

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<SignInRequest>({
    defaultValues: {
      email: "",
      password: "",
      rememberMe: false,
    },
  });

  const onSubmit = async (data: SignInRequest) => {
    try {
      const result = await authApi.signIn(data);
      if (result.data) {
        localStorage.setItem(
          LocalStorageKey.ACCESS_TOKEN,
          result.data.accessToken
        );
        navigate(ROUTES.Home);
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div
      style={{
        height: "100vh",
        background: "var(--main-color)",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Card variant="outlined" sx={{ width: "30%" }}>
        <CardContent>
          <Typography
            component="h1"
            variant="h3"
            sx={{
              width: "100%",
              marginBottom: "20px",
              fontWeight: "500",
              textAlign: "center",
              textTransform: "uppercase",
            }}
          >
            Sign in
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit(onSubmit)}
            sx={{ display: "flex", flexDirection: "column", gap: 2 }}
          >
            <Controller
              name="email"
              control={control}
              rules={{
                required: "Email is required",
                pattern: {
                  value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                  message: "Email is not correct format",
                },
              }}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Email"
                  fullWidth
                  placeholder="your@email.com"
                  autoComplete="email"
                  variant="outlined"
                  error={!!errors.email}
                  helperText={errors.email?.message}
                />
              )}
            ></Controller>
            <Controller
              name="password"
              control={control}
              rules={{
                required: "Password is required",
                minLength: {
                  value: 6,
                  message: "Password must be at least 6 characters",
                },
              }}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Password"
                  fullWidth
                  placeholder="••••••"
                  type="password"
                  autoComplete="new-password"
                  variant="outlined"
                  error={!!errors.password}
                  helperText={errors.password?.message}
                />
              )}
            ></Controller>
            <Controller
              name="rememberMe"
              control={control}
              render={({ field }) => (
                <FormControlLabel
                  control={
                    <Checkbox
                      {...field}
                      checked={field.value}
                      color="primary"
                    />
                  }
                  label="Remember me"
                  className={errors.rememberMe ? "text-red-600" : ""}
                />
              )}
            />
            <Button type="submit" fullWidth variant="contained">
              Sign in
            </Button>
            <Link
              component="button"
              type="button"
              variant="body2"
              sx={{
                alignSelf: "center",
                textDecoration: "none",
                fontSize: "1rem",
                margin: "10px 0",
              }}
            >
              Forgot your password?
            </Link>
          </Box>
          <Divider sx={{ marginBottom: "10px" }}>
            <Typography sx={{ color: "text.secondary" }}>or</Typography>
          </Divider>
          <Box sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <Button
              fullWidth
              variant="outlined"
              onClick={() => alert("Sign up with Google")}
              startIcon={<GoogleIcon />}
            >
              Sign up with Google
            </Button>
            <Typography sx={{ textAlign: "center" }}>
              Don't have an account?{" "}
              <Link
                href={ROUTES.SignUp}
                sx={{ alignSelf: "center", fontSize: "1rem" }}
              >
                Sign up
              </Link>
            </Typography>
          </Box>
        </CardContent>
      </Card>
    </div>
  );
}

export default SignIn;
