# Run
../AdvancedVersion/GSTORE/PCS/bin/Debug/netcoreapp3.1/PCS.exe < PCS/AdvancedVersion/Args.txt & PCSPID=$!
../AdvancedVersion/GSTORE/PuppetMaster/bin/Debug/netcoreapp3.1/PuppetMaster.exe

# Cleanup
kill -9 $PCSPID
