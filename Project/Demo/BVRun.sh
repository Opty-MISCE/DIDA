if [ "$#" -ne 1 ]; then
  echo "Usage: Takes Client Id As Argument" >&2
  exit 1
fi

# Run
../BasicVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/1/Args.txt & S1PID=$!
../BasicVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/2/Args.txt & S2PID=$!
../BasicVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/3/Args.txt & S3PID=$!
../BasicVersion/GSTORE/Client/bin/Debug/netcoreapp3.1/Client.exe < Clients/$1/Args.txt

# Cleanup
kill -9 $S1PID
kill -9 $S2PID
kill -9 $S3PID
