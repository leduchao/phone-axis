import {
  TextField,
  Typography,
  Box,
  FormControlLabel,
  Checkbox,
  Button,
  Divider,
  Link,
  Container,
  InputAdornment,
  IconButton,
} from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";
import { ROUTES } from "../../routes";
import { useNavigate } from "react-router";
import { authApi } from "../../apis/auth-api";
import { SignInRequest } from "../../models/auth-model";
import { LocalStorageKey } from "../../constants/local-storage";
import { Controller, useForm } from "react-hook-form";
import { FieldRules } from "../../constants/field-rules";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { useState } from "react";

function SignIn() {
  const navigate = useNavigate();

  const [showPassword, setShowPassword] = useState(false);
  const handleClickShowPassword = () => setShowPassword((show) => !show);

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
    <Container maxWidth="xs" sx={{ mt: 6 }}>
      <Typography
        component="div"
        variant="h3"
        sx={{
          mb: 6,
          fontWeight: "400",
          textAlign: "center",
        }}
      >
        Sign In
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
              value: FieldRules.EMAIL_REGEX,
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
              variant="standard"
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
              value: FieldRules.PASSWORD_MIN_LENGTH,
              message: `Password must be at least ${FieldRules.PASSWORD_MIN_LENGTH} characters`,
            },
          }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Password"
              fullWidth
              placeholder="••••••"
              type={showPassword ? "text" : "password"}
              autoComplete="new-password"
              variant="standard"
              error={!!errors.password}
              helperText={errors.password?.message}
              slotProps={{
                input: {
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        aria-label={
                          showPassword
                            ? "hide the password"
                            : "display the password"
                        }
                        onClick={handleClickShowPassword}
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  ),
                },
              }}
            />
          )}
        ></Controller>
        <Controller
          name="rememberMe"
          control={control}
          render={({ field }) => (
            <FormControlLabel
              control={
                <Checkbox {...field} checked={field.value} color="primary" />
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
            fontSize: "1rem",
            my: 1,
          }}
        >
          Forgot your password?
        </Link>
      </Box>

      <Divider sx={{ mb: 1 }}>
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
    </Container>
  );
}

export default SignIn;
